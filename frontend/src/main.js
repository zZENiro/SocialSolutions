import Vue from 'vue'
import VueMeta from 'vue-meta';
import App from './App.vue'
import './registerServiceWorker'
import moment from 'moment';
import router from './router'
import store from './store'
import '@/scss/style.scss';
import vuetify from './plugins/vuetify';
import 'ubuntu-fontface/_ubuntu.scss';
import axios from 'axios';
import Vuelidate from 'vuelidate';
import Base64 from 'crypto-js/enc-base64';
import ssCard from '@/components/ssCard.vue';
import DeskTitle from '@/components/DeskTitle.vue';
import {
  // debounce,
  // isEqual,
  // upperFirst,
  // find,
  // findKey,
  // merge,
  includes,
} from 'lodash';

moment.locale('ru');

Vue.config.productionTip = false

const axiosInstance = axios.create({
  baseURL: process.env.VUE_APP_API_SERVER,
  // withCredentials: true,
  // timeout: 1000,
  // headers: {
  //   'Content-Type': 'application/x-www-form-urlencoded',
  //   Accept: 'application/x-www-form-urlencoded',
  // },
});

// prototype section
Vue.prototype.$lodash = {
  // debounce,
  // isEqual,
  // upperFirst,
  // find,
  includes,
};
// Vue.prototype.$anime = anime
// Vue.prototype.$hammer = Hammer;
// Vue.prototype.$uuid = uuid;
Vue.prototype.$axios = axiosInstance;
Vue.prototype.$moment = moment;
Vue.prototype.$Base64 = Base64;
// Vue.prototype.$arrToSrcset = arrToSrcset;
// Vue.prototype.$iban = iban;

// use section
Vue.use(VueMeta);
Vue.use(Vuelidate);

// components
Vue.component('SsCard', ssCard);
Vue.component('DeskTitle', DeskTitle);

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
