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
                  :items="professions"
                  v-model="filters.profession"
                  label="Профессия"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-autocomplete>
              </v-col>
              <v-col cols="6">
                <v-autocomplete
                  :items="regions"
                  v-model="filters.region"
                  label="Регион"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-autocomplete>
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
              <v-col>
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
export default {
  data() {
    return {
      filters: {
        profession: '',
        region: '',
        rate: '',
        experience: '',
        options: [],
      },
      options: [
        'Полная занятость',
        'Частичная занятость',
        'Только доступные для людей с инвалидностью',
      ],
      professions: [
        'Верстальщик',
        'Программист',
        'Front-end разработчик',
      ],
      regions: [
        'Екатеринбург',
        'Пермь',
        'Тагил',
        'Ярославль',
      ],
      experiences: [
        'менее года',
        '1 - 3 года',
        '3 - 10 лет',
        'более 10 лет',
      ]
    }
  },
  mounted() {
    this.setFilters();
  },
  methods: {
    submit() {
      this.$router.push({ path: '/community/work', query: this.filters });
    },
    reset() {
      this.filters = {};
    },
    setFilters() {
      this.filters = this.$route.query;
    },
  },
}
</script>
