import '@mdi/font/css/materialdesignicons.css';
import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import ru from 'vuetify/es5/locale/ru';
// import colors from 'vuetify/lib/util/colors';

Vue.use(Vuetify);

export default new Vuetify({
  theme: {
      options: {
        customProperties: true,
      },
    themes: {
      light: {
        primary: '#0075FF',
        secondary: '#513B56',
        accent: '#82B1FF',
        error: '#FF003D',
        info: '#2196F3',
        success: '#36FD85',
        warning: '#FFC107'
      },
      dark: {
        primary: '#8888FF',
        secondary: '#888',
        accent: '#fff',
        error: '#FF003D',
        info: '#2196F3',
        success: '#36FD85',
        warning: '#FFC107'
      }
    },
  },
    lang: {
      locales: { ru },
      current: 'ru',
    },
});
