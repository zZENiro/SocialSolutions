<template>
  <v-app>
    <Drawer v-if="$route.path !== '/'" app :drawer.sync="drawer" :drawerMini.sync="drawerMini"/>
    <!-- <v-navigation-drawer permanent app></v-navigation-drawer>
    <v-app-bar app></v-app-bar> -->
    <AppBar app :drawer.sync="drawer" :drawerMini.sync="drawerMini" :menu="menu"/>

    <v-main>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </v-main>
    <BottomBar v-if="$vuetify.breakpoint.xsOnly" :menu="menu"/>
  </v-app>
</template>

<script>
import Drawer from '@/components/Drawer.vue';
import AppBar from '@/components/AppBar.vue';
import BottomBar from '@/components/BottomBar.vue';
import { mapState } from 'vuex'

export default {
  name: 'App',
  components: {
    Drawer,
    AppBar,
    BottomBar,
  },
  data: () => ({
    drawer: true,
    drawerMini: false,
    menu: [
      {
        title: 'Блог',
        href: '/blog',
        icon: 'mdi-forum',
      },
      {
        title: 'Сообщество',
        href: '/community',
        icon: 'mdi-account-group',
      },
      {
        title: 'Поддержать',
        href: '/donut',
        icon: 'mdi-handshake',
      },
    ],
  }),
  computed: {
    ...mapState(['badEye']),
  },
  watch: {
    badEye: {
      handler() {
        this.toggleDesign();
      },
    },
  },
  mounted() {
    const token = localStorage.getItem('token');
    const role = localStorage.getItem('role');
    const badEye = localStorage.getItem('badEye');
    if (token) {
      this.$store.dispatch('setToken', token);

      // TEMPORARY!!!!
      const user = localStorage.getItem('user');
      this.$store.commit('SET_USER', JSON.parse(user));
    }
    if (role) {
      this.$store.dispatch('setRole', JSON.parse(role));
    }

    // set badEye
    if (badEye) {
      this.$store.dispatch('setBadEye', badEye === 'true' ? true : false);
    }
  },
  methods: {
    toggleDesign() {
      console.log('toggle');
      if (this.badEye) {
        // document.documentElement.style.fontSize = '20px';
        this.$vuetify.theme.dark = true;
      } else {
        // document.documentElement.style.fontSize = '16px';
        this.$vuetify.theme.dark = false;
      }
    }
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
