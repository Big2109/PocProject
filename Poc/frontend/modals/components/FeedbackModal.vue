<template>
    <div class="modal fade" tabindex="-1" ref="modalEl">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header" :class="headerClass">
                    <h5 class="modal-title">{{ tituloModal }}</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>

                <div class="modal-body">
                    <p>{{ mensagem }}</p>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-primary" data-bs-dismiss="modal">OK</button>
                </div>

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted } from "vue";
import { Modal } from "bootstrap";

// ---------------------------------------------------------------------
// STATE
// ---------------------------------------------------------------------
const tipo = ref<"sucesso" | "erro" | "alerta">("alerta");
const mensagem = ref("");
const camposInvalidos = ref<string[]>([]);

const modalEl = ref<HTMLElement | null>(null);
let modalInstance: Modal | null = null;

// ---------------------------------------------------------------------
// INITIALIZATION
// ---------------------------------------------------------------------
onMounted(() => {
    if (modalEl.value) {
        modalInstance = new Modal(modalEl.value, { keyboard: false });
    }
});

// ---------------------------------------------------------------------
// PUBLIC API
// ---------------------------------------------------------------------
function open(
    novoTipo: "sucesso" | "erro" | "alerta",
    novaMensagem: string,
    listaCamposInvalidos: string[] = []
) {
    tipo.value = novoTipo ?? "alerta";
    mensagem.value = novaMensagem ?? "";
    camposInvalidos.value = listaCamposInvalidos;

    modalInstance?.show();
    aplicarErrosNosInputs();
}

defineExpose({ open });

// ---------------------------------------------------------------------
// ERROR HIGHLIGHTING
// ---------------------------------------------------------------------
function aplicarErrosNosInputs() {
    document.querySelectorAll(".input-erro").forEach(el =>
        el.classList.remove("input-erro")
    );

    camposInvalidos.value.forEach(campo => {
        const input = document.querySelector(`[name="${campo}"]`);
        if (!input) return;

        input.classList.add("input-erro");
        input.addEventListener("input", removerErroAoDigitar);
    });
}

function removerErroAoDigitar(e: Event) {
    const target = e.target as HTMLElement;
    target.classList.remove("input-erro");
    target.removeEventListener("input", removerErroAoDigitar);
}

// ---------------------------------------------------------------------
// COMPUTED
// ---------------------------------------------------------------------
const headerClass = computed(() => {
    switch (tipo.value) {
        case "sucesso": return "bg-success text-white";
        case "erro": return "bg-danger text-white";
        default: return "bg-warning text-dark";
    }
});

const tituloModal = computed(() => {
    switch (tipo.value) {
        case "sucesso": return "Sucesso";
        case "erro": return "Erro";
        default: return "Atenção";
    }
});
</script>
