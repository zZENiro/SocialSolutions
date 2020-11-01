import Vue from 'vue';
import Vuex from 'vuex';
import Base64 from 'crypto-js/enc-base64';
import Utf8 from 'crypto-js/enc-utf8';

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    token: null,
    submenu: [],
    mapFilters: {},
    mapList: false,
    user: {},
    role: {},
    badEye: false,
  },
  mutations: {
    SET_TOKEN(state, data) {
      state.token = data;
    },
    SET_SUBMENU(state, data) {
      state.submenu = data;
    },
    SET_MAP_FILTERS(state, data) {
      state.mapFilters = data;
    },
    SET_MAP_LIST(state, data) {
      state.mapList = data;
    },
    SET_USER(state, data) {
      state.user = data;
    },
    SET_ROLE(state, data) {
      state.role = data;
    },
    SET_BAD_EYE(state, data) {
      state.badEye = data;
    },
  },
  actions: {
    setToken({ commit }, data) {
      commit('SET_TOKEN', data);
      localStorage.setItem('token', data);

      // set def header
      this._vm.$axios.defaults.headers.common['Authorization'] = `Bearer ${data}`

      // parse token and set payload
      try {
        const payload = data.split('.')[1];
        console.log(Utf8.stringify(Base64.parse(payload)));
      } catch (error) {
        console.log(error);
      }
    },
    async setUser(/*{ commit }, data*/) {
      const url = '/api/user';
      try {
        const res = await this._vm.$axios.get(url);
        console.log(res.data);
      } catch (error) {
        console.log(error);
      }
    },
    setRole({ commit }, data) {
      commit('SET_ROLE', data);
      localStorage.setItem('role', JSON.stringify(data));
    },
    setBadEye({ commit }, data) {
      commit('SET_BAD_EYE', data);
      localStorage.setItem('badEye', data);
    },
    logout({ commit }) {
      commit('SET_TOKEN', null);
      localStorage.removeItem('token');
    },
  },
  modules: {
  },
})
