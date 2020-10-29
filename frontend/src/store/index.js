import Vue from 'vue';
import Vuex from 'vuex';
import Base64 from 'crypto-js/enc-base64';
import Utf8 from 'crypto-js/enc-utf8';

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    token: null,
  },
  mutations: {
    SET_TOKEN(state, data) {
      state.token = data;
    },
  },
  actions: {
    setToken({ commit }, data) {
      commit('SET_TOKEN', data);
      localStorage.setItem('token', data);

      // parse token and set payload
      try {
        const payload = data.split('.')[1];
        console.log(Utf8.stringify(Base64.parse(payload)));
      } catch (error) {
        console.log(error);
      }
    },
    logout({ commit }) {
      commit('SET_TOKEN', null);
      localStorage.removeItem('token');
    },
  },
  modules: {
  },
})
