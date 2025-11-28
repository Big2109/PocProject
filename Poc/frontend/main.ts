import { createApp } from "vue";
import ElDialog from "element-plus";
import 'element-plus/dist/index.css';
import Header from "./header/components/Header.vue";
import Menu from "./menu/components/Menu.vue";
import LandingContent from "./landing/components/LandingContent.vue";
import Particles from "./particles/components/Particles.vue";
import FeedbackModal from "./modals/components/FeedbackModal.vue";
import ConfirmacaoModal from "./modals/components/ConfirmacaoModal.vue";

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

// Modais
const modalsApp = createApp({});
modalsApp.component("FeedbackModal", FeedbackModal);
modalsApp.component("ConfirmacaoModal", ConfirmacaoModal);
modalsApp.mount("#modals-root");
