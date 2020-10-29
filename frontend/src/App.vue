<template>
  <v-app>
    <AppBar />

    <v-main>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </v-main>
  </v-app>
</template>

<script>
import AppBar from '@/components/AppBar.vue';

export default {
  name: 'App',
  components: {
    AppBar,
  },
  data: () => ({
    //
  }),
  mounted() {
    const token = localStorage.getItem('token');
    if (token) this.$store.dispatch('setToken', token);
  },
};
</script>
<style lang="scss">
  /* fade */
  .fade-enter-active, .fade-leave-active {
    transition: all ease-in-out .1s;
  }
  .fade-enter, .fade-leave-to {
    opacity: 0;
  }
  /* fade end */
</style>
