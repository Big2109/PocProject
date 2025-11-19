const { createApp: menu } = Vue;

menu({
    data() {
        return {
            items: [
                { title: 'Dashboard', description: 'Resumo geral do sistema.', link: '/Poc/dashboard' },
                { title: 'Usuários', description: 'Gerencie contas e permissões.', link: '/Configuracao/usuarios' },
                { title: 'Relatórios', description: 'Acompanhe indicadores.', link: '/Poc/relatorios' },
                { title: 'Configurações', description: 'Ajuste preferências do sistema.', link: '/Poc/config' }
            ]
        };
    },
    methods: {
        navegar(item) {
            const rotaAtual = window.location.pathname;

            if (rotaAtual !== item.link) {
                history.replaceState(null, "", item.link);
            } else {
                return;
            }

            toggleMenu();
        }
    }
}).mount("#menu");

function toggleMenu() {
    document.getElementById("menu").classList.toggle("expanded");
}
