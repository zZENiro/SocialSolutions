import Vue from 'vue'
import App from './App.vue'
import './registerServiceWorker'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify';
import 'roboto-fontface/css/roboto/roboto-fontface.css'
import '@mdi/font/css/materialdesignicons.css'
import axios from 'axios';
import Vuelidate from 'vuelidate';
import Base64 from 'crypto-js/enc-base64';

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
// Vue.prototype.$lodash = {
//   debounce,
//   isEqual,
//   upperFirst,
//   find,
// };
// Vue.prototype.$anime = anime
// Vue.prototype.$hammer = Hammer;
// Vue.prototype.$uuid = uuid;
Vue.prototype.$axios = axiosInstance;
// Vue.prototype.$moment = moment;
Vue.prototype.$Base64 = Base64;
// Vue.prototype.$arrToSrcset = arrToSrcset;
// Vue.prototype.$iban = iban;

// use section
// Vue.use(VueMeta);
Vue.use(Vuelidate);

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
