import { createApp } from "vue";
import Header from "./menu/components/Menu.vue";
import Menu from "./menu/components/Menu.vue";
import FeedbackModal from "./modals/components/FeedbackModal.vue";
import ConfirmacaoModal from "./modals/components/ConfirmacaoModal.vue";
import LandingContent from "./landing/components/LandingContent.vue";

import "./main.css"; // Tailwind

// Header
const headerApp = createApp(Header);
headerApp.mount("#HeaderApp");

// Menu
const menuApp = createApp(Menu);
menuApp.mount("#MenuApp");

// Landing
const landingApp = createApp(LandingContent);
landingApp.mount("#landing-content");

// Modais
const modalsApp = createApp({});
modalsApp.component("FeedbackModal", FeedbackModal);
modalsApp.component("ConfirmacaoModal", ConfirmacaoModal);
modalsApp.mount("#modals-root");
