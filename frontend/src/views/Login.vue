<template>
  <v-container fill-height>
    <v-row justify="center">
      <v-col cols="6">
        <Login/>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
import Login from '@/components/Login';

export default {
  components: {
    Login,
  }
}
</script>