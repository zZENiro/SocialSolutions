<template>
  <div>
    <div class="text-h3 mb-6 text-center text-md-left">Login</div>
    <form @submit.prevent="login">
      <v-text-field
        v-model="$v.username.$model"
        label="Username"
        outlined
        :error-messages="errorsUsername"
        :hide-details="'auto'"
        :disabled="loading"
        :loading="loading"
      ></v-text-field>
      <v-text-field
        v-model="$v.password.$model"
        label="password"
        type="password"
        outlined
        :error-messages="errorsPassword"
        :hide-details="'auto'"
        class="mt-3"
        :disabled="loading"
        :loading="loading"
      ></v-text-field>
      <v-btn
        class="mt-3"
        color="primary"
        block
        type="submit"
        :disabled="loading"
      >Login</v-btn>
      <v-btn
        class="mt-3"
        color="primary"
        outlined
        block
        type="button"
        @click="register"
        :disabled="loading"
      >Register</v-btn>
    </form>
  </div>
</template>
<script>
import {
  required,
  // minLength,
  // maxLength,
  // email,
  // sameAs,
  // numeric,
} from 'vuelidate/lib/validators';
import { mapState } from 'vuex';

export default {
  data() {
    return {
      username: '',
      password: '',
      errorsUsername: '',
      errorsPassword: '',
      loading: false,
    }
  },
  validations() {
    return {
      username: {
        required,
      },
      password: {
        required,
      },
    };
  },
  watch: {
    username: {
      handler() {
        this.$v.$touch();
        this.errorsUsername = this.$v.username.$error ? 'Error' : '';
      },
    },
    password: {
      handler() {
        this.$v.$touch();
        this.errorsPassword = this.$v.password.$error ? 'Error' : '';
      },
    },
    token: {
      immediate: true,
      handler(val) {
        if (val) {
          this.$router.push('/');
        }
      },
    },
  },
  computed: {
    ...mapState(['token']),
  },
  methods: {
    async login() {
      this.loading = true;
      const url = 'api/accounts/login';
      // const headers = {
      //   Authorization: process.env.VUE_APP_API_KEY,
      //   Token: this.token,
      //   lang: this.lang,
      // };
      const data = {
        login: this.username,
        password: this.password,
      };
      await this.callApi({url, data});
    },
    async register() {
      const url = 'api/accounts/register';
      const data = {
        login: this.username,
        password: this.password,
      };
      await this.callApi({url, data});
    },
    async callApi({ url, data, headers }) {
      this.loading = true;
      try {
        const res = await this.$axios.post(url, data, { headers });
        if (res.data.responseType !== 200 || !res.data.token) {
          this.errorsUsername = res.data.message;
          this.errorsPassword = res.data.message;
        } else  {
          this.$store.dispatch('setToken', res.data.token);
        }
      } catch (error) {
        console.log(error);
      }
      this.loading = false;
    },
  },
}
</script>
