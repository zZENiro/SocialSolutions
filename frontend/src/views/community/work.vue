<template>
  <div>
    <DeskTitle :image="2" subtitle="Искать работу">
      <template v-slot:title>
        Найдено <strong>{{ count }}</strong> вакансии
        <v-btn icon :to="{ path: 'filter', query: $route.query }" append class="ml-3"><v-icon>mdi-cog</v-icon></v-btn>
      </template>
    </DeskTitle>
    <v-container>
      <v-row>
        <v-col>
          <v-list>
            <template v-for="(item, i) in vacancies">
              <v-list-item :key="i">
                <v-list-item-content>
                  <div class="d-flex flex-column flex-md-row">
                    <div class="title primary--text my-3">{{ item.name }}</div>
                    <v-spacer></v-spacer>
                    <div v-if="item.salary" class="title my-3">
                      {{ item.salary.from }}
                      {{ item.salary.to && ' - ' }}
                      {{ item.salary.to }}
                      {{ currency[item.salary.currency] }}</div>
                  </div>
                  <div v-if="item.employer" class="grey--text">{{ item.employer.name }}</div>
                  <div v-if="item.address && item.address.city" class="grey--text d-flex align-center">
                    <v-icon color="grey" size="1rem">mdi-map-marker</v-icon>
                    <div>{{ item.address.city }}</div>
                  </div>
                  <div class="my-3" style="line-height:1.5;">
                    <p class="mb-0" v-if="item.snippet.requirement" >{{ item.snippet.requirement }}</p>
                    <p v-if="item.snippet.responsibility">{{ item.snippet.responsibility }}</p>
                  </div>
                  <div class="d-flex align-end mb-3">
                    <v-btn outlined rounded x-large color="primary">Откликнуться</v-btn>
                    <v-spacer></v-spacer>
                    <div class="grey--text">{{ humanize(item.published_at) }}</div>
                  </div>
                </v-list-item-content>
              </v-list-item>
              <v-divider :key="`divider-${i}`" ></v-divider>
            </template>
          </v-list>
        </v-col>
      </v-row>
      <v-row>
        <v-col>
          <v-pagination
            v-model="currentPage"
            :length="pages"
            circle
            :total-visible="7"
          ></v-pagination>
        </v-col>
      </v-row>
      <router-view></router-view>
    </v-container>
  </div>
</template>
<script>
import { mapState, mapGetters } from 'vuex';

export default {
  data() {
    return {
      apiKey: process.env.VUE_APP_SJ_KEY,
      hhId: process.env.VUE_APP_HH_ID,
      pages: 0,
      perPage: 10,
      hhQuery: {},
      vacancies: [],
      count: 0,
      currency: {
        RUR: 'руб.',
        USD: 'usd',
      },
    }
  },
  computed: {
    ...mapState('work', ['filters',]),
    ...mapGetters(['hhHeaders',]),
    currentPage: {
      get() {
        return Number.parseInt(this.$route.query.page || 1);
      },
      set(val) {
        if (val !== Number.parseInt(this.$route.query.page || 1))
        this.$router.push({ query: { page: val }});
      },
    },
  },
  watch: {
    currentPage() {
      this.getVacanciesHh();
    }
  },
  mounted() {
    this.getVacanciesHh();
  },
  methods: {
    async getVacancies() {
      const url = '/api/Vacancies/getcatalogs';
      await this.callApi({ url });
    },
    getVacanciesHh() {
      // get head hunter vacancies
      const url = 'https://api.hh.ru/vacancies?label=accept_handicapped';
      const params = {
        ...this.filters,
        per_page: this.perPage,
        page: this.currentPage - 1,
      };
      this.callApi({ url, params, headers: this.hhHeaders })
        .then((data) => {
          if (data.items) {
            this.vacancies = data.items;
            this.pages = data.pages;
            this.count = data.found;
          }
        })
    },
    async callApi({ url, params, headers }) {
      this.loading = true;
      let result = null;
      try {
        const res = await this.$axios.get(url, { params }, { headers });
        result = res.data;
        console.log(result);
      } catch (error) {
        throw new Error(error);
      } finally {
        this.loading = false;
      }
      return result;
    },
    humanize(datetime) {
      let res = this.$moment(datetime);
      if (Math.abs(res.diff(this.$moment(), 'days')) > 5) {
        res = res.format('D MMMM');
      } else res = this.$moment(datetime).fromNow();
      return res;
    }
  },
}
</script>
