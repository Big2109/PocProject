<template>
  <div v-if="show" class="modal">
    <div class="relative bg-gradient-to-t from-gray600 to-gray700 rounded-lg shadow-lg p-5 w-90 text-center">
      <button @click="show = false"
              class="absolute top-2 right-3 text-gray400 text-xl hover:text-gray300">
        &times;
      </button>
      <div class="p-3">
        <span>
          <i class="fas fa-trash-can fa-2x text-red-500"></i>
        </span>
      </div>
      <p class="text-white mb-6" v-html="mensagem"></p>
      <div class="flex justify-between gap-10 border-t pt-3 border-gray500">
        <a class="cancel-btn" @click="show = false" href="#">Cancelar</a>
        <a class="confirm-btn" @click.prevent="confirm(`deletar-usuario/${guidUsuario}`)" href="#">Confirmar</a>
      </div>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted } from 'vue'

const show = ref(false)
const mensagem = ref('')
let guidUsuario: string | null = null

onMounted(() => {
  const confirmacaoApp = document.getElementById('ConfirmacaoApp')
  if(!confirmacaoApp) return;
})

window.ShowConfirmacaoModal = (msg: string, id: string) => {
  mensagem.value = msg
  show.value = true
  guidUsuario = id
}

async function confirm(route: string): Promise<void> {
  if (!guidUsuario) return

  try {
    const res = await fetch(route, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json'
      }
    })

    if (!res.ok) {
      alert('Erro ao deletar usuário.')
    }
    else {
      show.value = false;
      window.location.href = '/configuracao/usuarios';
    }
  } catch (err) {
    console.error(err)
    alert('Erro inesperado.')
  }
}
</script>
