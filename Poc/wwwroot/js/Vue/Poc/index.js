createApp({
    data() {
        return {
            features: [
                { title: 'Login Seguro', description: 'Autenticação com validação na base de dados.' },
                { title: 'Gestão de Usuários', description: 'Controle completo de usuários e permissões.' },
                { title: 'Relatórios', description: 'Visualize relatórios em tempo real.' },
            ]
        };
    },
    methods: {
        ctaClick() {
            alert("Você clicou em 'Saiba Mais'!");
        }
    }
}).mount("#landing-content");