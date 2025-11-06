// const { createApp, ref } = Vue

// createApp({
//     setup() {
//         const clientes = ref([])

//         // Função para buscar clientes
//         const listarClientes = async () => {
//             const res = await fetch('http://localhost:3000/clientes/listar')
//             clientes.value = await res.json()
//         }

//         return { clientes, listarClientes }
//     }
// }).mount('#app')
