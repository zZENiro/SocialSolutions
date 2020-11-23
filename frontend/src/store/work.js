export default ({
  namespaced: true,
  state: {
    filters: {},
  },
  mutations: {
    SET_FILTERS(state, data) {
      state.token = data;
    },
  },
});
