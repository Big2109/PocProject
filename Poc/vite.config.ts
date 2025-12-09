import { defineConfig } from "vite";
import vue from "@vitejs/plugin-vue";
import { resolve } from "path";

export default defineConfig({
    plugins: [vue()],
    build: {
        outDir: "wwwroot/dist",
        emptyOutDir: true,
        cssCodeSplit: true,
        rollupOptions: {
            input: {
                main: resolve(__dirname, "frontend/main.ts")
            },
            output: {
                entryFileNames: "[name].bundle.js",
                assetFileNames: "[name].[ext]"
            }
        }
    }
});
