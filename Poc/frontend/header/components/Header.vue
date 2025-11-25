<template>
  <nav class="shadow-md relative">
    <div class="container-fluid flex items-center justify-between px-4 py-2">
      <!-- Logo -->
      <a class="text-center break-words" href="/" title="Home">
        <i class="logo"></i>
      </a>

      <!-- Botão de toggle (mobile only) -->
      <button
        class="text-white md:hidden text-gray-700 focus:outline-none"
        @click="expanded = !expanded"
        aria-label="Toggle navigation"
      >
        ☰
      </button>
    </div>

    <!-- Menu colapsável -->
    <div
      class="md:flex md:items-center md:justify-between w-full px-4 py-2 md:py-0"
      :class="{'hidden': !expanded, 'block': expanded}"
    >
      <ul class="navbar-nav flex flex-col md:flex-row md:space-x-6">
        <li>
          <a href="/Poc/dashboard" class="block py-1 md:py-0">Dashboard</a>
        </li>
        <li>
          <a href="/Configuracao/usuarios" class="block py-1 md:py-0">Usuários</a>
        </li>
        <li>
          <a href="/Poc/relatorios" class="block py-1 md:py-0">Relatórios</a>
        </li>
        <li>
          <a href="/Poc/config" class="block py-1 md:py-0">Configurações</a>
        </li>
      </ul>

      <!-- Login/Sair -->
      <div class="flex justify-end md:justify-start gap-2 mt-2 md:mt-0">
        <template v-if="isAuthenticated">
          <span class="flex items-center gap-2">
            <i class="fas fa-circle-user"></i>{{ userName }}
          </span>
          <!-- <a href="/login/sair" class="btn btn-primary text-white">Sair</a> -->
           <button href="/login/sair"
            class="text-white bg-[#24234a] border border-white min-w-[140px] px-4 py-2 rounded hover:bg-[#5670c7] transition-colors duration-200">
            Sair
            </button>
        </template>
        <template v-else>
          <a href="/login" class="btn btn-primary text-white">Login</a>
        </template>
      </div>
    </div>
  </nav>
</template>


<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
  setup() {
    const expanded = ref(false);

    const isAuthenticated = true;
    const userName = "João da Silva";

    return { expanded, isAuthenticated, userName };
  },
});
</script>
