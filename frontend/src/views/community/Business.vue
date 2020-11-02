<template>
  <v-container fluid fill-height pa-0 class="flex-column">
    <transition name="fade">
      <div class="map-loading" v-if="loading"></div>
    </transition>
    <transition name="fade" mode="out-in" tag="div">
      <div v-if="!mapList" style="flex:1;min-width:100%;" :key="1">
        <Map :organizations="organizations" />
      </div>
      <v-container v-if="mapList" :key="2">
        <div class="text-h3 my-6 my-sm-12 ml-3">Список объектов</div>
        <v-list>
          <template v-for="(item, i) in organizations">
            <v-list-item :key="i" three-line>
              <v-list-item-content>
                <v-list-item-title>{{ item.Caption }}</v-list-item-title>
                <v-list-item-subtitle>Адрес: {{ item.Contact.Address }}</v-list-item-subtitle>
                <v-list-item-subtitle>Телефон: {{ item.Contact.Phone }}</v-list-item-subtitle>
              </v-list-item-content>
              <v-list-item-action>
                <div class="d-flex">
                  <template v-for="(icon, key) in item.Dostup">
                    <v-icon color="success" class="ml-3" :key="key"  v-if="item.Dostup[key] === 2">{{ mapIcons[key] }}</v-icon>
                  </template>
                </div>
              </v-list-item-action>
            </v-list-item>
            <v-divider :key="`divider-${i}`"></v-divider>
          </template>
        </v-list>
      </v-container>
    </transition>
  </v-container>
</template>
<script>
import Map from '@/components/Map.vue';
import { mapState } from 'vuex';

export default {
  components: {
    Map,
  },
  data() {
    return {
      organizations: [],
      loading: false,
      mapIcons: {
        Dost_Kolyas: 'mdi-wheelchair-accessibility',
        Dost_ODA: 'mdi-human-cane',
        Dost_Sluh: 'mdi-ear-hearing-off',
        Dost_Um: 'mdi-brain',
        Dost_Zren: 'mdi-eye-off'
      }
    }
  },
  computed: {
    ...mapState(['mapList', 'mapFilters']),
  },
  watch: {
    mapFilters: {
      deep: true,
      handler() {
        this.getOrgs();
      },
    },
  },
  metaInfo() {
    return {
      meta: [
        // { name: 'viewport', content: 'width=device-width, initial-scale=1.0, user-scalable=no' },
      ],
    };
  },
  mounted() {
    // call api for get data
    this.getOrgs();
  },
  methods: {
    async getOrgs() {
      const url = '/api/freeenv/getresult';
      const { region } = this.mapFilters;
      const { sfera } = this.mapFilters;
      const data = `{"inputsParam":'{"regnId":"66053000","regnText":"${region}","sferaId":"11","sferaText":"${sfera}","vidId":null,"vidText":null,"captionId":null,"captionText":null,"captionOsiId":null,"captionOsiText":null}'}`;
      const headers = {
        'Content-Type': 'application/json',
      };
      await this.callApi({ url, data, headers });
    },
    async callApi({ url, data, headers }) {
      this.loading = true;
      try {
        const res = await this.$axios.post(url, data, { headers });
        const result = JSON.parse(res.data.d).Result;
        this.organizations = result;
      } catch (error) {
        console.log(error);
      }
      this.loading = false;
    },
  },
}
</script>
<style lang="scss">
  .map-loading {
    pointer-events: none;
    position: absolute;
    top: 0;
    left: 0;
    max-height: 100vh;
    width: 100%;
    height: 100%;
    background-color: rgba($color: #ccd8ff, $alpha: .5);
    backdrop-filter: blur(3px);
    z-index: 1000;
  }
  .map-loading::after {
    content: " ";
    pointer-events: none;
    position: absolute;
    width: 8rem;
    height: 8rem;
    border-radius: 50%;
    border: 5px solid;
    border-color: var(--v-primary-base) transparent var(--v-primary-base) transparent;
    top: calc(50vh - 4rem);
    left: calc(50% - 4rem);
    z-index: 1000;
    animation: lds-dual-ring 1.2s linear infinite;
  }

  @keyframes lds-dual-ring {
    0% {
      transform: rotate(0deg);
    }
    100% {
      transform: rotate(360deg);
    }
  }
</style>
