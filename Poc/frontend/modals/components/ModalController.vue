<template></template>
<script lang="ts" setup>
window.ShowModal = (id: string) => {
    const el = document.getElementById(id);
    if (!el) return;
    el.classList.remove("d-none");
};

window.HideModal = (id: string) => {
    const el = document.getElementById(id);
    if (!el) return;
    el.classList.add("d-none");
};
</script>