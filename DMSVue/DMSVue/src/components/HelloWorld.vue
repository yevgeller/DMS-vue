<template>
    <div class="post">
        <div v-if="loading" class="loading">
            Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationvue">https://aka.ms/jspsintegrationvue</a> for more details.
        </div>
        <div>Tutorial <a href="https://docs.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-vue?view=vs-2022">here.</a></div>
        <div v-if="post" class="content">
            <table class="table">
                <thead>
                    <tr>
                        <th>Date</th>
                        <th>Temp. (C)</th>
                        <th>Temp. (F)</th>
                        <th>Summary</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="forecast in post" :key="forecast.date">
                        <td>{{ processDate(forecast.date) }}</td>
                        <td>{{ forecast.temperatureC }}</td>
                        <td>{{ forecast.temperatureF }}</td>
                        <td>{{ forecast.summary }}</td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="ts">
    import Vue from 'vue';

    type Forecasts = {
        date: string
    }[];

    interface Data {
        loading: boolean,
        post: null | Forecasts
    }

    export default Vue.extend({
        data(): Data {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData(): void {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => { console.log(r); return r.json(); })
                    .then(json => {
                        console.log(json);
                        this.post = json as Forecasts;
                        this.loading = false;
                        return;
                    });
            },
            processDate(d: Date): string {
                const dd = new Date(d);
                return dd.getDate() + "-" + (dd.getMonth() + 1) + "-" + dd.getFullYear();
            }
        },
    });
</script>