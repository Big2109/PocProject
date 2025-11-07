const { createApp: showModal } = Vue;

showModal({
    setup() {
        const tipo = ref('alerta');
        const mensagem = ref('');
        const camposInvalidos = ref([]);
        let modalInstance = null;

        onMounted(() => {
            const modalEl = document.getElementById('feedback-modal');
            modalInstance = new bootstrap.Modal(modalEl, { keyboard: false });
        });

        const showFeedbackModal = (novoTipo, novaMensagem, listaCamposInvalidos = []) => {
            tipo.value = novoTipo || 'alerta';
            mensagem.value = novaMensagem || '';
            camposInvalidos.value = listaCamposInvalidos || [];

            modalInstance.show();
            aplicarErrosNosInputs();
        };

        const aplicarErrosNosInputs = () => {
            document.querySelectorAll(".input-erro").forEach(el => {
                el.classList.remove("input-erro");
            });

            camposInvalidos.value.forEach(campo => {
                const input = document.querySelector(`[name="${campo}"]`);
                if (input)
                    input.classList.add("input-erro");
                input.addEventListener('input', removerErroAoDigitar);
            });
        };

        const removerErroAoDigitar = (event) => {
            event.target.classList.remove('input-erro');
            event.target.removeEventListener('input', removerErroAoDigitar);
        };

        window.showFeedbackModal = showFeedbackModal;

        return { tipo, mensagem };
    }
}).mount('#feedback');
