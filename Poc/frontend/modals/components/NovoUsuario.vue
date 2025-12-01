<template>
  <div v-if="show" class="modal">
      <div class="card h-[450px] w-[450px] text-center">
        <div class="flex justify-end">
          <button @click="show = false"
                  class="top-2 right-3 text-gray400 text-xl hover:text-gray300">
            &times;
          </button>
        </div>
        <form asp-controller="Login" asp-action="Registrar" method="post"
            class="flex flex-col gap-4 w-full max-w-md mx-auto px-4 sm:px-3">
            <div class="flex flex-col">
                <label asp-for="Nome">Nome</label>
                <input asp-for="Nome" type="text" />
            </div>
            <div class="flex flex-col">
                <label asp-for="NomeUsuario">Nome do usuário</label>
                <input asp-for="NomeUsuario" type="text" />
            </div>
            <div class="flex flex-col">
                <label asp-for="Email">Email</label>
                <input asp-for="Email" type="email" />
            </div>
            <div class="flex flex-col">
                <label asp-for="Senha">Senha</label>
                <input asp-for="Senha" type="password" />
            </div>
            <div class="flex flex-column justify-center py-4">
                <button type="submit" class="login-btn bg-gray400">
                    Registrar
                </button>
            </div>
        </form>
    </div>
  </div>
</template>

<script lang="ts" setup>
import { ref, onMounted, computed } from 'vue'

const show = ref(false)

onMounted(() => {
  const appDiv = document.getElementById('NovoUsuarioApp')
  if(!appDiv) return

  const s = appDiv.dataset.show

  if(s){
    show.value = true
  }
})
</script>
