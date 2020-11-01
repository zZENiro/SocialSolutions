<template>
  <v-list>
    <v-divider></v-divider>
    <v-subheader>Категория</v-subheader>
    <v-list-item @click="list = !list" class="mb-3">
      <v-list-item-action>
        <v-checkbox :value="list"></v-checkbox>
      </v-list-item-action>
      <v-list-item-content>
        <v-list-item-title>Список</v-list-item-title>
      </v-list-item-content>
    </v-list-item>
    <v-list-item class="my-3">
      <v-select
        v-model="filters.region"
        :items="availableRegions"
        label="Регион"
        outlined
        rounded
        :hide-details="'auto'"
      ></v-select>
    </v-list-item>
    <v-list-item class="my-3">
      <v-select
        v-model="filters.sfera"
        :items="availableSferas"
        label="Сфера"
        outlined
        rounded
        :hide-details="'auto'"
      ></v-select>
    </v-list-item>
    <v-list-item class="my-3">
      <v-select
        v-model="filters.vid"
        :items="availableVids"
        label="Вид объекта"
        outlined
        rounded
        :hide-details="'auto'"
      ></v-select>
    </v-list-item>
    <v-subheader>Признак доступности</v-subheader>
    <v-list-item-group v-model="filters.problems" multiple>
      <v-list-item
        v-for="(item, i) in problems"
        :key="i"
        :value="item.value"
        active-class="primary--text"
      >
        <v-list-item-icon>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          {{ item.title }}
        </v-list-item-content>
      </v-list-item>
    </v-list-item-group>
    <v-list-item class="my-3">
      <v-btn color="error" @click="filters = { ...availableFilters }" depressed outlined large rounded block>Очистить</v-btn>
    </v-list-item>
    <template v-slot:append>
      <div class="pa-2">
        <v-btn block>
          Logout
        </v-btn>
      </div>
    </template>
  </v-list>
</template>
<script>
import { mapState } from 'vuex';

export default {
  data() {
    return {
      availableRegions: [
        'Город Первоуральск',
        'Талицкий район',
        'Не указано',
      ],
      availableSferas: [
        'Иные объекты',
        'Объекты в сфере занятости населения',
        'Объекты в сфере здравоохранения',
        'Объекты в сфере культуры',
        'Не указано',
      ],
      availableVids: [
        'Пенсионные фонды',
        'Аптеки',
        'Государственные учреждения здравоохранения - городские больницы',
        'Не указано',
      ],
      availableFilters: {
        region: '',
        sfera: '',
        vid: '',
        problems: [],
      },
      filters: {
        region: '',
        sfera: '',
        vid: '',
        problems: [],
      },
      problems: [
        {
          title: 'Для людей с нарушением зрения',
          icon: 'mdi-eye-off',
          value: 'Для людей с нарушением зрения',
        },
        {
          title: 'Для людей с нарушением слуха',
          icon: 'mdi-ear-hearing-off',
          value: 'Для людей с нарушением слуха',
        },
        {
          title: 'Для людей с нарушением умственного развития',
          icon: 'mdi-brain',
          value: 'Для людей с нарушением умственного развития',
        },
        {
          title: 'Для людей передвигающихся на креслах-колясках',
          icon: 'mdi-wheelchair-accessibility',
          value: 'Для людей передвигающихся на креслах-колясках',
        },
        {
          title: 'Для людей с нарушением опорно-двигательной системы',
          icon: 'mdi-human-cane',
          value: 'Для людей с нарушением опорно-двигательной системы',
        },
      ],
      list: false,
    }
  },
  computed: {
    ...mapState(['mapList']),
  },
  watch: {
    filters: {
      deep: true,
      handler(val) {
        this.$store.commit('SET_MAP_FILTERS', val);
      },
    },
    list: {
      handler(val) {
        this.$store.commit('SET_MAP_LIST', val);
      },
    }
  },
  mounted() {
    this.list = this.mapList;
  },
}
</script>
