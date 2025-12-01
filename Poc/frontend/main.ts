import { createApp } from "vue";
import Header from "./header/components/Header.vue";
import Menu from "./menu/components/Menu.vue";
import LandingContent from "./landing/components/LandingContent.vue";
import Particles from "./particles/components/Particles.vue";
import Feedback from "./modals/components/Feedback.vue";
import Confirmacao from "./modals/components/Confirmacao.vue";
import NovoUsuario from "./modals/components/NovoUsuario.vue";

import "./main.css"; // Tailwind

// Header
const headerApp = createApp(Header);
headerApp.mount("#HeaderApp");

// Menu
const menuApp = createApp(Menu);
menuApp.mount("#MenuApp");

// Landing
const landingApp = createApp(LandingContent);
landingApp.mount("#LandingApp");

// Particles
const particlesApp = createApp(Particles);
particlesApp.mount("#ParticlesApp");

// Modals
const feedback = createApp(Feedback);
feedback.mount("#FeedbackApp");

const confirmacao = createApp(Confirmacao);
confirmacao.mount("#ConfirmacaoApp");

const novoUsuario = createApp(NovoUsuario);
novoUsuario.mount("#NovoUsuarioApp");
