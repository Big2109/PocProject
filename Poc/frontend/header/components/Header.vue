<!-- <script lang="ts">
import { defineComponent, ref, onMounted } from "vue";

interface LoginStatus {
  isLogged: boolean;
  userName: string;
}

export default defineComponent({
  setup() {
    const isAuthenticated = ref(false);
    const userName = ref("");

    const checkLogin = async () => {
      try {
        const response = await fetch("/Login/IsLogged");
        if (!response.ok) throw new Error("Erro ao verificar login");

        const data: LoginStatus = await response.json();
        isAuthenticated.value = data.isLogged;
        userName.value = data.userName;
      } catch (error) {
        console.error(error);
        isAuthenticated.value = false;
        userName.value = "";
      }
    };

    onMounted(() => {
      checkLogin();
    });

    return { isAuthenticated, userName };
  },
});
</script> -->

<script lang="ts">
import { defineComponent, ref } from "vue";

export default defineComponent({
  setup() {
    const isAuthenticated = ref((window as any).__USER__?.isAuthenticated ?? false);
    const userName = ref((window as any).__USER__?.name ?? "");
    const show = ref((window as any).__USER__?.show ?? true);

    return { isAuthenticated, userName, show };
  }
});
</script>

<template>
  <nav aria-label="Global" class="mx-auto flex max-w-7xl items-center justify-between p-3 lg:px-8">
    <div class="flex lg:flex-1">
      <a href="#" class="-m-1.5 p-1.5">
        <span class="sr-only">Your Company</span>
        <!-- <img src="https://tailwindcss.com/plus-assets/img/logos/mark.svg?color=indigo&shade=500" alt="" class="h-8 w-auto" /> -->
      </a>
    </div>
    <div class="flex lg:hidden">
      <button type="button" command="show-modal" commandfor="mobile-menu" class="-m-2.5 inline-flex items-center justify-center rounded-md p-2.5 text-gray-400">
        <span class="sr-only">Open main menu</span>
        <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" data-slot="icon" aria-hidden="true" class="size-6">
          <path d="M3.75 6.75h16.5M3.75 12h16.5m-16.5 5.25h16.5" stroke-linecap="round" stroke-linejoin="round" />
        </svg>
      </button>
    </div>
    <div class="hidden lg:flex">
      <template v-if="show">
        <template v-if="isAuthenticated">
          <span class="d-flex mx-5 my-auto text-white">
            <i class="pr-1 fas fa-user-circle"></i>
            {{ userName }}
          </span>
          <a href="/login/sair" class="login-btn">Sair</a>
        </template>
        <template v-else>
          <a href="/login" class="login-btn">Login</a>
        </template>
      </template>
    </div>
  </nav>
  <el-dialog>
    <dialog id="mobile-menu" class="backdrop:bg-transparent lg:hidden">
      <div tabindex="0" class="fixed inset-0 focus:outline-none">
        <el-dialog-panel class="fixed inset-y-0 right-0 z-50 w-full overflow-y-auto bg-gray600 p-6 sm:max-w-sm sm:ring-1 sm:ring-gray-100/10">
          <div class="flex items-center justify-between">
            <a href="#" class="-m-1.5 p-1.5">
              <span class="sr-only">Your Company</span>
              <template v-if="isAuthenticated">
                <span class="d-flex mx-2 text-white">
                  <i class="pr-1 fas fa-user-circle"></i>
                  {{ userName }}
                </span>
              </template>
            </a>
            <button type="button" command="close" commandfor="mobile-menu" class="-m-2.5 rounded-md p-2.5 text-gray-400">
              <span class="sr-only">Close menu</span>
              <svg viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" data-slot="icon" aria-hidden="true" class="size-6">
                <path d="M6 18 18 6M6 6l12 12" stroke-linecap="round" stroke-linejoin="round" />
              </svg>
            </button>
          </div>
          <div class="mt-6 flow-root">
            <div class="-my-6 divide-y divide-white/10">
              <div class="space-y-2 py-6">
                <a href="#" class="-mx-3 block rounded-lg px-3 py-2 text-base/7 font-semibold text-white hover:bg-white/5">Features</a>
                <a href="#" class="-mx-3 block rounded-lg px-3 py-2 text-base/7 font-semibold text-white hover:bg-white/5">Marketplace</a>
                <a href="#" class="-mx-3 block rounded-lg px-3 py-2 text-base/7 font-semibold text-white hover:bg-white/5">Company</a>
              </div>
              <div class="py-6 flex flex-col items-center gap-4">
                <template v-if="show">
                  <template v-if="isAuthenticated">
                    <a href="/login/sair" class="login-btn">Sair</a>
                  </template>
                  <template v-else>
                    <a href="/login" class="login-btn">Login</a>
                  </template>
                </template>
              </div>
            </div>
          </div>
        </el-dialog-panel>
      </div>
    </dialog>
  </el-dialog>
</template>
