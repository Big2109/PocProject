<template>
  <div v-if="show" class="modal">
    <div class="relative bg-gradient-to-t from-gray600 to-gray700 rounded-lg shadow-lg p-6 w-80 text-center">
      <button @click="show = false"
              class="absolute top-2 right-3 text-gray400 text-xl hover:text-gray300">
        &times;
      </button>
      <div class="p-3">
        <span>
          <i :class="tituloClass"></i>
        </span>
      </div>
      <p class="text-white mb-4" v-html="mensagem"></p>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, computed } from 'vue'

const show = ref(false)
const tipo = ref('')
const mensagem = ref('')

const tituloClass = computed(() => {
  switch (tipo.value) {
    case "sucesso":
      return "fas fa-check-circle fa-3x text-green-600";
    case "alerta":
      return "fas fa-exclamation-triangle fa-3x text-yellow-500";
    case "erro":
      return "fas fa-times-circle fa-3x text-red-600";
    default:
      return "fas fa-info-circle fa-3x text-gray-600";
  }
});

onMounted(() => {
  const appDiv = document.getElementById('FeedbackApp')
  if(!appDiv) return

  const t = appDiv.dataset.tipoMensagem
  const m = appDiv.dataset.mensagem

  if(m){
    tipo.value = t ?? 'erro'
    mensagem.value = m
    show.value = true
  }
})
</script>
