import { ref, onMounted } from "vue"
import type { ChartData, ChartOptions } from "chart.js"

export function UseHorizontalChart(elementId: string) {
    const chartData = ref<ChartData<'bar'> | null>(null)

    const chartOptions: ChartOptions<"bar"> = {
        responsive: true,
        indexAxis: "x",
        scales: {
            x: {
                type: "time",
                time: {
                    unit: "day",
                    tooltipFormat: "dd/MM/yyyy"
                },
                title: {
                    display: true,
                    text: "Mês"
                }
            },
            y: {
                beginAtZero: true,
                min: 0,
                max: 5,
                ticks: {
                    stepSize: 1
                }
            }
        }
    };

    onMounted(() => {
        const el = document.getElementById(elementId)
        if (!el) return

        const labels = JSON.parse(el.dataset.labels || "[]").map((d: string) => new Date(d));
        const values = JSON.parse(el.dataset.values || "[]")

        chartData.value = {
            labels,
            datasets: [
                {
                    label: el.dataset.labeltext ?? "Valores",
                    data: values,
                    backgroundColor: "#5670c7",
                    borderRadius: 8
                }
            ]
        }
    })

    return { chartData, chartOptions }
}
