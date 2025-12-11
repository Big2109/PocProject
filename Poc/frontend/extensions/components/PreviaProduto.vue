<template>
  <div class="w-full">
    <h2 class="text-center">Prévia</h2>
    <ul class="flex space-x-4 py-4">
      <li class="card-produto text-center mt-4">
        <i
          v-if="icon"
          :class="[icon, 'fa-5x']"
          :style="{ color }"
        ></i>
        <p v-if="icon" class="mt-3">
          <strong>Ícone:</strong> {{ icon }}<br>
          <strong>Cor:</strong> {{ color }}
        </p>
        <div v-else class="text-gray-400 mt-6">
          <i class="fas fa-info-circle fa-3x mb-2 opacity-50"></i>
          <p>Selecione um ícone</p>
        </div>
      </li>
      <li>
        <div class="card-produto text-center mt-4"></div>
      </li>
    </ul>
</div>
</template>

<script setup lang="ts">
defineProps<{
  icon: string
  color: string
}>();
</script>
