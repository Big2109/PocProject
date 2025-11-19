const { createApp: particles, ref, onMounted } = Vue;

particles({
    setup() {
        onMounted(() => {
            tsParticles.load("tsparticles", {
                background: {
                    color: {
                        value: "#0f0d40"
                    }
                },
                fpsLimit: 60,
                particles: {
                    number: {
                        value: 65,
                        density: {
                            enable: true,
                            area: 600
                        }
                    },
                    color: { value: "#ffffff" },
                    shape: { type: "circle" },
                    opacity: { value: 0.1 },
                    size: { value: { min: 1, max: 4 } },
                    move: {
                        enable: true,
                        speed: 1,
                        direction: "none",
                        outModes: { default: "bounce" }
                    },
                    links: {
                        enable: true,
                        distance: 140,
                        color: "#ffffff",
                        opacity: 0.1,
                        width: 1
                    }
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
            });
        });
    }
}).mount("#particles");