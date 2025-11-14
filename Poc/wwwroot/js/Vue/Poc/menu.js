const { createApp: menu } = Vue;

menu({
    data() {
        return {
            items: [
                { title: 'Dashboard', description: 'Resumo geral do sistema.', link: 'Poc/dashboard' },
                { title: 'Usuários', description: 'Gerencie contas e permissões.', link: 'Poc/usuarios' },
                { title: 'Relatórios', description: 'Acompanhe indicadores.', link: 'Poc/relatorios' },
                { title: 'Configurações', description: 'Ajuste preferências do sistema.', link: 'Poc/config' }
            ]
        };
    }
}).mount("#menu");

function toggleMenu() {
    document.getElementById("menu").classList.toggle("expanded");
}