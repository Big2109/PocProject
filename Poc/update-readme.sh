#!/bin/bash
set -e

README="README.md"
TEMP_FILE="README.tmp"

echo "🧱 Atualizando estrutura do projeto (apenas pastas)..."

generate_with_tree() {
  tree -d -a -I "bin|obj|.git|.vscode|node_modules|structure.txt|README.md" --charset ascii
}

generate_with_find() {
  echo "📂 'tree' não encontrado — usando 'find'..."
  find . -type d \
    -not -path "./bin*" \
    -not -path "./obj*" \
    -not -path "./.git*" \
    -not -path "./.vscode*" \
    -not -path "./node_modules*" \
    -not -path "./structure.txt" \
    -not -path "./README.md" \
    | sort \
    | awk '{
        n = split($0, parts, "/");
        indent="";
        for (i = 2; i < n; i++) indent = indent "│   ";
        print indent "├── " parts[n];
      }'
}

if command -v tree >/dev/null 2>&1; then
  STRUCTURE=$(generate_with_tree)
else
  STRUCTURE=$(generate_with_find)
fi

if [ -z "$STRUCTURE" ]; then
  echo "❌ Nenhum conteúdo encontrado."
  exit 1
fi

for marker in "<!-- BEGIN STRUCTURE -->" "<!-- END STRUCTURE -->"; do
  if ! grep -q "$marker" "$README"; then
    echo "❌ Marcador $marker não encontrado no README.md"
    exit 1
  fi
done

# Usa arquivo temporário para evitar "Argument list too long"
STRUCT_FILE=$(mktemp)
echo "$STRUCTURE" > "$STRUCT_FILE"

echo "🔄 Inserindo estrutura no README.md..."

awk -v struct_file="$STRUCT_FILE" '
  BEGIN { inside=0 }
  /<!-- BEGIN STRUCTURE -->/ {
    print
    print "```"
    while ((getline line < struct_file) > 0) print line
    print "```"
    close(struct_file)
    inside=1
    next
  }
  /<!-- END STRUCTURE -->/ {
    inside=0
  }
  !inside { print }
' "$README" > "$TEMP_FILE"

mv "$TEMP_FILE" "$README"
rm "$STRUCT_FILE"

echo "✅ README.md atualizado com sucesso!"
