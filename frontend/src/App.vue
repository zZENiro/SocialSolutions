<template>
  <v-app>
    <v-app-bar
      app
      color=""
    >
      <div class="d-flex align-center">Social Solutions</div>

      <v-spacer></v-spacer>

      <v-btn
        to="/login"
        color="primary"
      >
        Login
      </v-btn>
    </v-app-bar>

    <v-main>
      <transition name="fade" mode="out-in">
        <router-view></router-view>
      </transition>
    </v-main>
  </v-app>
</template>

<script>
export default {
  name: 'App',
  data: () => ({
    //
  }),
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
