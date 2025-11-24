const { createApp: confirmacao } = Vue;

confirmacao({
    setup() {
        const mensagem = ref('');
        let modalInstance = null;

        onMounted(() => {
            const modalEl = document.getElementById('confirmacao-modal');
            modalInstance = new bootstrap.Modal(modalEl, { keyboard: false });
        });

        const showConfirmacaoModal = (novaMensagem) => {
            mensagem.value = novaMensagem || '';

            modalInstance.show();
            aplicarErrosNosInputs();
        };

        window.showConfirmacaoModal = showConfirmacaoModal;

        return { mensagem };
    }
}).mount('#modal-confirmacao');