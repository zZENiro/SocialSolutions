<template>
  <div>
    <div class="text-h3 mb-6">Login</div>
    <form @submit.prevent="login">
      <v-text-field
        v-model="username"
        label="Username"
        outlined
      ></v-text-field>
      <v-text-field
        v-model="password"
        label="password"
        type="password"
        outlined
      ></v-text-field>
      <v-btn block type="submit">Login</v-btn>
    </form>
  </div>
</template>
<script>
export default {
  data() {
    return {
      username: '',
      password: '',
    }
  },
  methods: {
    login() {
      const url = 'api/accounts/login';
      // const headers = {
      //   Authorization: process.env.VUE_APP_API_KEY,
      //   Token: this.token,
      //   lang: this.lang,
      // };

      const data = {
        username: this.username,
        password: this.password,
      };

      this.$axios.post(url, data);
    },
  },
}
</script>
