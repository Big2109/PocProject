<template>
    <div class="modal fade" tabindex="-1" ref="modalEl">
        <div class="modal-dialog">
            <div class="modal-content">

                <div class="modal-header bg-primary text-white">
                    <h5 class="modal-title">Confirmação</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>

                <div class="modal-body">
                    <p>{{ mensagem }}</p>
                </div>

                <div class="modal-footer">
                    <button class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button class="btn btn-primary" @click="confirmarAcao">Confirmar</button>
                </div>

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";
import { Modal } from "bootstrap";

const mensagem = ref("");
const modalEl = ref<HTMLElement | null>(null);
let modalInstance: Modal | null = null;
let callbackConfirmacao: (() => void) | null = null;

onMounted(() => {
    if (modalEl.value) {
        modalInstance = new Modal(modalEl.value, { keyboard: false });
    }
});

// -------- API pública exposta ao pai --------
function open(msg: string, callback?: () => void) {
    mensagem.value = msg;
    callbackConfirmacao = callback || null;

    modalInstance?.show();
}

function confirmarAcao() {
    if (callbackConfirmacao) callbackConfirmacao();
    modalInstance?.hide();
}

defineExpose({
    open
});
</script>
