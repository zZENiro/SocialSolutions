<template>
  <div>
    <DeskTitle image="2" subtitle="Искать работу">
      <template v-slot:title>
        Найдено <strong>2034</strong> вакансии
        <v-btn icon :to="{ path: 'filter', query: $route.query }" append class="ml-3"><v-icon>mdi-cog</v-icon></v-btn>
      </template>
    </DeskTitle>
    <v-container>
      <v-row>
        <v-col>
          <v-list>
            <template v-for="(item, i) in Array(5)">
              <v-list-item :key="i">
                <v-list-item-content>
                  <div class="d-flex flex-column flex-md-row">
                    <div class="title primary--text my-3">Frontend-разработчик</div>
                    <v-spacer></v-spacer>
                    <div class="title my-3">150 000 - 180 000 rub.</div>
                  </div>
                  <div class="my-3" style="line-height:1.5;">Документирование программного кода, верификация программного кода других разработчиков. Своевременное ведение учета выполненных работ. Оценка объема работы по сформированным техническим заданиям.</div>
                  <div class="d-flex align-end my-3">
                    <v-btn outlined rounded x-large color="primary">Откликнуться</v-btn>
                    <v-spacer></v-spacer>
                    <div class="grey--text">today</div>
                  </div>
                </v-list-item-content>
              </v-list-item>
              <v-divider :key="`divider-${i}`" ></v-divider>
            </template>
          </v-list>
        </v-col>
      </v-row>
      <router-view></router-view>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      apiKey: process.env.VUE_APP_SJ_KEY,
    }
  },
  mounted() {
    // this.getVacancies();
  },
  methods: {
    getVacancies() {
      const url = '/api/Vacancies/getcatalogs';
      this.callApi({ url });
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
