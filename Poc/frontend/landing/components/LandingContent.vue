<template>
    <section class="py-20">
        <div class="text-center">
            <h1>Bem-vindo à nossa aplicação!</h1>
            <h2>Uma POC moderna com .NET e Vue.js. Explore nossos recursos abaixo.</h2>
            <div class="max-w-3xl mx-auto">
                <div class="card max-w-screen-sm text-colortextlight" v-for="f in features" :key="f.title">
                    <h3>{{ f.title }}</h3>
                    <p>{{ f.description }}</p>
                </div>
            </div>
            <button @click="ctaClick">Saiba Mais</button>
        </div>
    </section>
</template>

<script lang="ts">
import { defineComponent } from "vue";

export default defineComponent({
    data() {
        return {
            features: [
                { title: 'Login Seguro', description: 'Autenticação com validação na base de dados.' },
                { title: 'Gestão de Usuários', description: 'Controle completo de usuários e permissões.' },
                { title: 'Relatórios', description: 'Visualize relatórios em tempo real.' },
                { title: 'Integrações', description: 'Integre seus sistemas com a gente.' },
            ]
        }
    },
    methods: {
        ctaClick() {
            alert("Você clicou em 'Saiba Mais'!");
        }
    }
});
</script>
