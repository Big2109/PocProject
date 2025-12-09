<script lang="ts">
import { defineComponent, onMounted } from "vue";

export default defineComponent({
  name: "Particles",
  setup() {
    onMounted(async () => {
      const engine = (window as any).tsParticles;
      if (!engine) {
        console.warn("tsParticles não encontrado no window. Verifique se o CDN foi carregado.");
        return;
      }

      const options = {
        background: {
          color: {
            value: "#121212"
          }
        },
        fpsLimit: 60,
        particles: {
          number: {
            value: 65,
            density: { enable: true, area: 600 }
          },
          color: { value: "#ccc" },
          shape: { type: "circle" },
          opacity: { value: 0.1 },
          size: { value: { min: 1, max: 4 } },
          move: { enable: true, speed: 1, direction: "none", outModes: { default: "bounce" } },
          links: { enable: true, distance: 140, color: "#ccc", opacity: 0.1, width: 1 }
        },
        interactivity: {
          events: {
            onHover: { enable: true, mode: "repulse" },
            onClick: { enable: true, mode: "push" }
          },
          modes: {
            repulse: { distance: 100 },
            push: { quantity: 4 }
          }
        },
        detectRetina: true
      };

      try {
        await engine.load("tsparticles", options);
      } catch (err) {
        console.error("Erro inicializando tsParticles:", err);
      }
    });

    return {};
  }
});
</script>

<template>
     <div id="tsparticles" class="absolute inset-0 -z-10"></div>
</template>