<template>
  <v-container>
    <v-row>
      <v-col>
        <div class="text-h5 my-6 my-md-12">
          Найдено 2034 вакансии
          <v-btn icon to="filter" append class="ml-3"><v-icon>mdi-cog</v-icon></v-btn>
        </div>
      </v-col>
    </v-row>
    <router-view></router-view>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      apiKey: process.env.VUE_APP_SJ_KEY,
    }
  },
  mounted() {
    // this.getScript();
  },
  methods: {
    getScript() {
      const url = 'https://api.superjob.ru/2.0/vacancies/';
      const headers = {
        'X-Api-App-Id': this.apiKey,
      };
      this.callApi({ url, headers });
    },
    async callApi({ url, data, headers }) {
      this.loading = true;
      try {
        const res = await this.$axios.get(url, data, { headers });
        const result = res.data;
        console.log(result);
      } catch (error) {
        console.log(error);
      }
      this.loading = false;
    },
  },
}
</script>
