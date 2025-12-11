<template>
    <h2 class="text-lg font-semibold my-6">Escolha um ícone:</h2>

    <!-- Ícones -->
    <div class="grid grid-cols-3 sm:grid-cols-4 md:grid-cols-6 gap-5">
      <div
        v-for="icon in icons"
        :key="icon"
        class="flex items-center justify-center cursor-pointer transition-all"
        @click="selectIcon(icon)">
        <i
          :class="[
            icon,
            selectedIcon === icon
              ? 'fa-3x text-gray300 scale-110'
              : 'fa-3x text-gray500 opacity-60 hover:opacity-100 hover:scale-110 duration-200'
          ]"
          :style="selectedIcon === icon ? { color: selectedColor } : {}">
        </i>
      </div>
    </div>

    <h2 class="text-lg font-semibold my-6">Escolha uma cor:</h2>

    <!-- Cores -->
    <div class="grid grid-cols-3 sm:grid-cols-4 md:grid-cols-6 gap-5">
      <div
        v-for="color in colors"
        :key="color"
        :style="{ backgroundColor: color }"
        class="w-12 h-12 mx-auto rounded-lg cursor-pointer border-2 transform hover:scale-110 duration-200 transition-all"
        :class="selectedColor === color ? 'border-black scale-110' : 'border-transparent'"
        @click="selectColor(color)">
      </div>
    </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';

const icons = [
  'fas fa-gears',
  'fas fa-user',
  'fas fa-heart',
  'fas fa-star',
  'fas fa-home',
  'fas fa-exclamation-circle',
];

const colors = [
  '#F87171', '#FBBF24', '#34D399',
  '#60A5FA', '#A78BFA', '#F472B6'
];

const selectedName = ref('');
const selectedIcon = ref('');
const selectedColor = ref('');

function selectName(name: string) {
  selectedName.value = name;

  const input = document.querySelector<HTMLInputElement>('input[name="Nome"]');
  if (input) input.value = name;
}

function selectIcon(icon: string) {
  selectedIcon.value = icon;

  const input = document.querySelector<HTMLInputElement>('input[name="Icone"]');
  if (input) input.value = icon;
}

function selectColor(color: string) {
  selectedColor.value = color;

  const input = document.querySelector<HTMLInputElement>('input[name="CorHex"]');
  if (input) input.value = color;
}

watch([selectedName, selectedIcon, selectedColor], ([name, icon, color ]) => {
  window.dispatchEvent(
    new CustomEvent("update-product", {
      detail: { name, icon, color }
    })
  );
});

document.addEventListener("input", (e: any) => {
  if (e.target?.name === "Nome") {
    selectName(e.target.value);
  }
});

</script>

<style scoped></style>
