#!/bin/bash
set -e

README="README.md"
TEMP_FILE="README.tmp"

echo "🧱 Atualizando estrutura do projeto..."

# Função que gera estrutura usando tree
generate_with_tree() {
  tree -a -I "bin|obj|.git|.vscode|structure.txt|README.md" --charset ascii
}

# Função alternativa usando find
generate_with_find() {
  echo "📂 'tree' não encontrado — usando 'find'..."
  find . \
    -not -path "./bin*" \
    -not -path "./obj*" \
    -not -path "./.git*" \
    -not -path "./.vscode*" \
    -not -path "./structure.txt" \
    -not -path "./README.md" \
    | sort \
    | awk '{
      n = split($0, parts, "/");
      indent = "";
      for (i = 2; i < n; i++) indent = indent "│   ";
      if (n > 1) {
        print indent "├── " parts[n];
      } else {
        print parts[n];
      }
    }'
}

# Detecta se 'tree' está instalado
if command -v tree >/dev/null 2>&1; then
  STRUCTURE=$(generate_with_tree)
else
  STRUCTURE=$(generate_with_find)
fi

# Verifica se o conteúdo foi gerado
if [ -z "$STRUCTURE" ]; then
  echo "❌ Nenhum conteúdo encontrado."
  exit 1
fi

# Verifica os marcadores
for marker in "<!-- BEGIN STRUCTURE -->" "<!-- END STRUCTURE -->"; do
  if ! grep -q "$marker" "$README"; then
    echo "❌ Marcador $marker não encontrado no README.md"
    exit 1
  fi
done

echo "🔄 Inserindo estrutura no README.md..."

# Substitui o conteúdo entre os marcadores, preservando linhas
awk -v content="$STRUCTURE" '
  BEGIN { inside=0 }
  /<!-- BEGIN STRUCTURE -->/ {
    print
    print "```"
    print content
    print "```"
    inside=1
    next
  }
  /<!-- END STRUCTURE -->/ {
    inside=0
  }
  !inside { print }
' "$README" > "$TEMP_FILE"

mv "$TEMP_FILE" "$README"

echo "✅ README.md atualizado com sucesso!"
