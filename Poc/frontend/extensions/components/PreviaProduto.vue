<template>
    <div v-if="color"
    class="card-produto text-center m-4 !w-[350px] !h-[350px] transition-all duration-300"
    @mouseenter="hover = true"
    @mouseleave="hover = false"
    :style="{
      border: hover ? '3px solid ' + color : '2px solid transparent',
      color: color
    }">
      <h3 class="text-5xl pb-4" v-if="name"
        :style="{ color }">{{name}}</h3>
      <i
        v-if="icon"
        :class="[icon, 'fa-8x']"
        :style="{ color }"></i>
      <p v-if="icon" class="mt-3"></p>
      <div v-else class="text-gray-400 mt-6">
        <i class="fas fa-info-circle fa-3x mb-2 opacity-50"></i>
        <p>Selecione um ícone</p>
      </div>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from "vue";

const hover = ref(false);

const name = ref("");
const icon = ref("");
const color = ref("");

onMounted(() => {
  const appDiv = document.getElementById("IconPreviewApp");
  if (appDiv) {
    name.value = appDiv.getAttribute("data-current-name") || "";
    icon.value = appDiv.getAttribute("data-current-icon") || "";
    color.value = appDiv.getAttribute("data-current-color") || "";
  }
});

window.addEventListener("update-product", (e: any) => {
  name.value = e.detail.name;
  icon.value = e.detail.icon;
  color.value = e.detail.color;
});
</script>
