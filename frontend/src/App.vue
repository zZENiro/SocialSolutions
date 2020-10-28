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
      <router-view></router-view>
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
