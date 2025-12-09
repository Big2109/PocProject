import { createApp } from "vue";
import Header from "./header/components/Header.vue";
import Menu from "./menu/components/Menu.vue";
import LandingContent from "./landing/components/LandingContent.vue";
import Particles from "./particles/components/Particles.vue";
import Feedback from "./modals/components/Feedback.vue";
import ModalController from "./modals/components/ModalController.vue";
import CriarProdutoOptions from "./extensions/components/CriarProdutoOptions.vue";

import "./main.css"; // Tailwind

// Header
const header = createApp(Header);
header.mount("#HeaderApp");

// Menu
const menu = createApp(Menu);
menu.mount("#MenuApp");

// Landing
const landing = createApp(LandingContent);
landing.mount("#LandingApp");

// Particles
const particles = createApp(Particles);
particles.mount("#ParticlesApp");

// Modals
const modalController = createApp(ModalController);
modalController.mount("#ModalControllerApp");

const feedback = createApp(Feedback);
feedback.mount("#FeedbackApp");

//Extensions
const criarProdutoOptions = createApp(CriarProdutoOptions);
criarProdutoOptions.mount("#IconOptionsApp");
