<template>
    <div id="landing-content">
        <section class="hero-section">
            <div class="text-center">
                <h1>Bem-vindo à nossa aplicação!</h1>
                <h2>Uma POC moderna com .NET e Vue.js. Explore nossos recursos abaixo.</h2>
                <div v-for="f in features" :key="f.title">
                    <h3>{{ f.title }}</h3>
                    <p>{{ f.description }}</p>
                </div>
                <button @click="ctaClick">Saiba Mais</button>
            </div>
        </section>
    </div>
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
