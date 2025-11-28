<template>
    <div class="flex h-screen">

        <!-- SIDEBAR -->
        <aside
            class="group bg-gray600 text-white py-5 space-y-4 hidden md:block
                   w-[80px] hover:w-[270px] transition-all duration-300 overflow-hidden">

            <nav class="flex flex-col space-y-2">

                <!-- ITEM DO MENU -->
                <a href="/configuracao/usuarios"
                   class="text-gray300 flex items-center gap-3 py-4 pl-2 rounded-lg hover:text-blue transition-all duration-200">

                    <!-- ÍCONE (sempre visível) -->
                    <i class="fas fa-users fa-2x"></i>

                    <!-- TEXTO (só aparece no hover da sidebar) -->
                    <h2 class="text-blue mb-0 whitespace-nowrap opacity-0 group-hover:opacity-100
                               transition-opacity duration-300">
                        Usuários
                    </h2>
                </a>

            </nav>
        </aside>

    </div>
</template>
