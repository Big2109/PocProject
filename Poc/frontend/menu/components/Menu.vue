<script setup lang="ts">
interface MenuItem {
  label: string;
  icon: string;
  href: string;
}

const menuItems: MenuItem[] = [
    {
    label: "Dashboard",
    icon: "fas fa-chart-pie fa-2x",
    href: "/poc/index",
  },
  {
    label: "Usuários",
    icon: "fas fa-users fa-2x",
    href: "/configuracao/usuarios",
  },
    {
    label: "Produtos",
    icon: "fas fa-shop fa-2x",
    href: "/produto",
  },
  {
    label: "Configurações",
    icon: "fas fa-cog fa-2x",
    href: "/configuracao",
  },
  {
    label: "Relatórios",
    icon: "fas fa-chart-bar fa-2x",
    href: "/relatorios",
  },
];
</script>

<template>
  <div class="absolute flex h-screen z-10">
    <aside
      class="group bg-gray600 text-white py-3 space-y-4
             w-[70px] hover:w-[240px] transition-all duration-300 overflow-hidden">
      <nav class="flex flex-col space-y-2">
         <a
          v-for="item in menuItems"
          :key="item.href"
          :href="item.href"
          class="group flex items-center gap-3 m-0 p-3
                 text-gray300 hover:bg-gray700 transition-all duration-200">

          <i :class="item.icon + ' pl-1 group-hover:text-blue transition-colors duration-200'"></i>

          <h3 class="mb-0 whitespace-nowrap opacity-0 group-hover:opacity-100
                     group-hover:text-blue transition-all duration-300">
            {{ item.label }}
          </h3>
        </a>
      </nav>
    </aside>
  </div>
</template>
