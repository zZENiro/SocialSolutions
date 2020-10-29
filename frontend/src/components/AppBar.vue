<template>
  <v-app-bar
    app
    color=""
  >
    <div class="d-flex align-center">Social Solutions</div>
    <v-spacer></v-spacer>
    <v-btn
      to="/login"
      color="primary"
      outlined
      v-if="!token"
    >
      Login
    </v-btn>
    <v-btn
      v-else
      icon
      title="Logout"
      @click="logout"
    >
      <v-icon>mdi-logout</v-icon>
    </v-btn>
  </v-app-bar>
</template>
<script>
import { mapState } from 'vuex';

export default {
  data() {
    return {
      //
    }
  },
  computed: {
    ...mapState(['token']),
  },
  methods: {
    logout() {
      this.$store.dispatch('logout');
    },
  },
}
</script>
