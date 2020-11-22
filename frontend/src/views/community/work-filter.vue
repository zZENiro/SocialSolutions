<template>
  <div>
    <DeskTitle image="2">
      <template v-slot:title>
        Фильтр
        <v-btn icon to="/community/work" append class="ml-3" title="Назад"><v-icon>mdi-chevron-left</v-icon></v-btn>
      </template>
    </DeskTitle>
    <v-container>
      <v-row>
        <v-col>
          <form @submit.prevent="submit">
            <v-row>
              <v-col cols="6">
                <v-autocomplete
                  :items="countries"
                  item-text="name"
                  item-value="id"
                  v-model="filters.country"
                  label="Регион"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  :items="areas"
                  item-text="name"
                  item-value="id"
                  v-model="filters.area"
                  label="Регион"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  :items="specializations"
                  item-text="name"
                  item-value="id"
                  deletable-chips
                  v-model="filters.specialization"
                  label="Профессия"
                  chips
                  outlined
                  multiple
                  rounded
                  :hide-details="'auto'"
                >
                  <template v-slot:item="data">
                    <template v-if="!('isSub' in data.item)">
                      <v-list-item-title>{{ data.item.name }}</v-list-item-title>
                    </template>
                    <template v-else>
                      <v-list-item-content>
                        <v-list-item-subtitle class="gray">{{ data.item.name }}</v-list-item-subtitle>
                      </v-list-item-content>
                    </template>
                  </template>
                </v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  :items="experiences"
                  v-model="filters.experience"
                  label="Опыт"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-text-field
                  v-model="filters.rate"
                  label="Уровень зарплаты"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-text-field>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  :items="options"
                  v-model="filters.options"
                  label="Параметры"
                  deletable-chips
                  multiple
                  outlined
                  rounded
                ></v-autocomplete>
              </v-col>
            </v-row>
            <div class="d-flex mt-3">
              <v-btn color="primary" depressed rounded x-large type="submit">Применить</v-btn>
              <v-btn type="button" @click="reset" class="ml-3" color="primary" rounded outlined x-large >Сбросить</v-btn>
            </div>
          </form>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import { mapGetters } from 'vuex';

export default {
  data() {
    return {
      // filters: {
      //   specialization: '',
      //   area: '',
      //   country: '',
      //   rate: '',
      //   experience: '',
      //   options: [],
      // },
      options: [
        'Полная занятость',
        'Частичная занятость',
        'Только доступные для людей с инвалидностью',
      ],
      specializations: [],
      areas: [],
      countries: [],
      experiences: [
        'менее года',
        '1 - 3 года',
        '3 - 10 лет',
        'более 10 лет',
      ]
    }
  },
  computed: {
    ...mapGetters(['hhHeaders',]),
    filters: {
      get() {
        return this.$store.state.work.filters;
      },
      set(val) {
        this.commit('SET_FILTERS', val);
      },
    }
  },
  watch: {
    'filters.country'(val) {
      this.getAreas(val);
    },
  },
  mounted() {
    this.getCountries();
    this.getSpecializations();
  },
  methods: {
    submit() {
      this.$router.push({ path: '/community/work', query: this.filters });
    },
    reset() {
      this.commit('SET_FILTERS', {});
    },
    getCountries() {
      const url = 'https://api.hh.ru/areas/countries';
      this.$axios.get(url, { headers: this.hhHeader })
        .then((res) => {
          this.countries = res.data;
        });
    },
    getAreas(parentId) {
      // get child areas
      const url = `https://api.hh.ru/areas/${parentId}`;
      this.$axios.get(url, { headers: this.hhHeader })
        .then((res) => {
          this.areas = res.data.areas;
        })
    },
    getSpecializations() {
      // get professions
      const url = 'https://api.hh.ru/specializations';
      this.$axios.get(url, { headers: this.hhHeader })
        .then((res) => {
          this.specializations = res.data.reduce((acc, cur) => {
            acc.push({ id: cur.id, name: cur.name, });
            cur.specializations.forEach((sp) => {
              acc.push({ ...sp, isSub: true, });
            });
            return acc;
          }, []);
        })
    },
  },
}
</script>
