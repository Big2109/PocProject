<script setup lang="ts">
import { ref } from "vue";
import PreviaProduto from "./PreviaProduto.vue";

const previewIcon = ref("");
const previewColor = ref("");

window.addEventListener("update-product", (e: any) => {
  previewIcon.value = e.detail.icon;
  previewColor.value = e.detail.color;
});
</script>

<template>
  <PreviaProduto
    :icon="previewIcon"
    :color="previewColor"
  />
</template>
