<template>
  <v-app>
    <Drawer app :drawer.sync="drawer" :drawerMini.sync="drawerMini" />
    <!-- <v-navigation-drawer permanent app></v-navigation-drawer>
    <v-app-bar app></v-app-bar> -->
    <AppBar app :drawer.sync="drawer" :drawerMini.sync="drawerMini" :bad-eye.sync="badEye" />

    <v-main>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </v-main>
  </v-app>
</template>

<script>
import Drawer from '@/components/Drawer.vue';
import AppBar from '@/components/AppBar.vue';

export default {
  name: 'App',
  components: {
    Drawer,
    AppBar,
  },
  data: () => ({
    drawer: true,
    drawerMini: false,
    badEye: false,
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

  /* SLIDE-TOP */
  .slide-top-enter-active, .slide-top-leave-active {
    transition: all .2s ease-in-out;
  }
  .slide-top-enter, .slide-top-leave-to {
    transform: translateY(-50%);
    opacity: 0;
  }
  /* END SLIDE-TOP */
</style>
