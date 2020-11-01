<template>
  <v-container fill-height>
    <v-row>
      <v-col justify="center" class="text-center">
        <div class="">
          <img v-if="!$vuetify.theme.dark" style="max-width:80%;" src="@/assets/img/logo1.svg" alt="">
          <img v-else style="max-width:80%;" src="@/assets/img/logo1-dark.svg" alt="">
        </div>
        <v-btn color="primary mt-5" to="/login" v-if="!token">Login</v-btn>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import { mapState } from 'vuex'
export default {
  name: 'Home',
  computed: {
    ...mapState(['token']),
  },
}
</script>
