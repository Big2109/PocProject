module.exports = {
  content: [
    "./Views/**/*.cshtml",
    "./Pages/**/*.cshtml",
    "./frontend/**/*.{html,js,ts,jsx,tsx,vue}"
  ],
  theme: {
    extend: {
      colors: {
        gray900: '#121212', // fundo principal
        gray800: '#1E1E1E', // seções / cards
        gray700: '#2C2C2C', // backgrounds menores
        gray600: '#3A3A3A', // bordas / divisores / menus
        gray500: '#525252', // texto secundário
        gray400: '#737373', // texto menos importante
        gray300: '#A3A3A3', // texto leve / legendas
      }
    }
  },
  plugins: [],
};
