<template>
  <Bar v-if="chartData" :data="chartData" :options="chartOptions" />
</template>

<script setup lang="ts">
import { Bar } from "vue-chartjs"
import {
  Chart as ChartJS,
  Title,
  Tooltip,
  Legend,
  BarElement,
  CategoryScale,
  LinearScale,
  TimeScale
} from "chart.js"

import "chartjs-adapter-date-fns"
import { UseHorizontalChart } from "../useHorizontalChart"

ChartJS.register(Title, Tooltip, Legend, BarElement, CategoryScale, LinearScale, TimeScale)

const { chartData, chartOptions } = UseHorizontalChart("ProdutosChart")
</script>
