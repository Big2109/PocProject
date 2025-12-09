<template>
  <div class="p-4">
    <h2 class="text-lg font-semibold mb-4">Escolha um ícone:</h2>

    <!-- Ícones -->
    <div class="grid grid-cols-5 gap-6 mb-8">
      <div
        v-for="icon in icons"
        :key="icon"
        class="flex items-center justify-center cursor-pointer transition-all"
        @click="selectIcon(icon)"
      >
        <i
          :class="[
            icon,
            selectedIcon === icon
              ? 'fa-3x text-gray300 scale-110'
              : 'fa-3x text-gray500 opacity-60 hover:opacity-100 hover:scale-110'
          ]"
          :style="selectedIcon === icon ? { color: selectedColor } : {}"
        ></i>
      </div>
    </div>

    <h2 class="text-lg font-semibold mb-4">Escolha uma cor:</h2>

    <!-- Cores -->
    <div class="grid grid-cols-6 gap-4">
      <div
        v-for="color in colors"
        :key="color"
        :style="{ backgroundColor: color }"
        class="w-12 h-12 rounded-lg cursor-pointer border-2 transition-transform transform hover:scale-110"
        :class="selectedColor === color ? 'border-black scale-110' : 'border-transparent'"
        @click="selectColor(color)"
      ></div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue';

const icons: string[] = [
  'fas fa-gears',
  'fas fa-user',
  'fas fa-heart',
  'fas fa-star',
  'fas fa-home',
];

const colors: string[] = [
  '#F87171', '#FBBF24', '#34D399',
  '#60A5FA', '#A78BFA', '#F472B6'
];

const selectedIcon = ref<string>('');
const selectedColor = ref<string>('');

function selectIcon(icon: string) {
  selectedIcon.value = icon;

  const input = document.querySelector<HTMLInputElement>('input[name="Icone"]');
  if (input) {
    input.value = icon;
  }
}

function selectColor(color: string) {
  selectedColor.value = color;

  const input = document.querySelector<HTMLInputElement>('input[name="CorHex"]');
  if (input) {
    input.value = color;
  }
}
</script>

<style scoped></style>
