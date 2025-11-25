<template>
    <div :class="{ expanded: expanded }">
        <div @click="toggleHeader">
            ☰
        </div>

        <ul>
            <li v-for="item in items" :key="item.title">
                <a :href="item.link">
                    <strong>{{ item.title }}</strong>
                    <p>{{ item.description }}</p>
                </a>
            </li>
        </ul>
    </div>
</template>

<script lang="ts">
import { defineComponent, ref } from "vue";

interface HeaderItem {
    title: string;
    description: string;
    link: string;
}

export default defineComponent({
    name: "Header",

    setup() {
        const expanded = ref(false);

        const items = ref<HeaderItem[]>([
            { title: "Dashboard", description: "Resumo geral do sistema.", link: "/Poc/dashboard" },
            { title: "Usuários", description: "Gerencie contas e permissões.", link: "/Configuracao/usuarios" },
            { title: "Relatórios", description: "Acompanhe indicadores.", link: "/Poc/relatorios" },
            { title: "Configurações", description: "Ajuste preferências do sistema.", link: "/Poc/config" },
        ]);

        const toggleHeader = () => {
            expanded.value = !expanded.value;
        };

        return { expanded, items, toggleHeader };
    }
});
</script>
