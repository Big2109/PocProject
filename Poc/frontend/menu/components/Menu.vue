<template>
  <div class="flex h-screen">
    <aside
      class="group bg-gray600 text-white py-5 space-y-4 hidden md:block
             w-[80px] hover:w-[270px] transition-all duration-300 overflow-hidden">
      <nav class="flex flex-col space-y-2 px-2">
        <a href="/configuracao/usuarios"
           class="group flex items-center gap-3 py-4 rounded-lg
                  text-gray-300 hover:bg-gray-700 transition-all duration-200">
          <i class="fas fa-users fa-2x group-hover:text-blue-500 transition-colors duration-200"></i>
          <h2
            class="mb-0 whitespace-nowrap opacity-0 group-hover:opacity-100
                   group-hover:text-blue-500 transition-all duration-300">
            Usuários
          </h2>
        </a>
      </nav>
    </aside>
  </div>
</template>
