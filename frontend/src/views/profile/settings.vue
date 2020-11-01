<template>
  <div>
    <DeskTitle>
      <template v-slot:title>
        <div>Настройки</div>
        <div class="row no-gutters align-center mt-6">
          <div class="text-h5 mr-3 col-auto">Я: </div>
          <v-select
            :items="roles"
            :value="role"
            @change="(val) => $store.dispatch('setRole', val)"
            label="Ваша роль на сайте"
            item-text="name"
            item-id="name"
            outlined
            rounded
            return-object
            :hide-details="'auto'"
            class="col col-md-auto"
            :loading="loading"
            :disabled="loading"
          ></v-select>
        </div>
      </template>
    </DeskTitle>
    <v-container>
      <v-row>
        <v-col>
          <form @submit.prevent="submit">
            <v-row>
              <v-col cols="12" md="6" class="d-flex align-center">
                <v-text-field
                  v-model="form.name"
                  label="Имя"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-text-field>
              </v-col>
              <v-col cols="12" md="6" class="d-flex align-center">
                <v-text-field
                  v-model="form.secondName"
                  label="Фамилия"
                  outlined
                  rounded
                  :hide-details="'auto'"
                ></v-text-field>
              </v-col>
            </v-row>
            <div class="d-flex mt-3">
              <v-btn color="primary" depressed rounded x-large @click="submit" type="submit">Применить</v-btn>
              <v-btn type="button" @click="reset" class="ml-3" color="primary" rounded outlined x-large >Сбросить</v-btn>
            </div>
          </form>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
import { mapState } from 'vuex';

export default {
  data() {
    return {
      form: {
        role: '',
      },
      roles: [],
      loading: false,
    }
  },
  computed: {
    ...mapState(['user', 'role']),
  },
  mounted() {
    this.getRoles();
    this.reset();
  },
  methods: {
    getRoles() {
      const url = '/api/roles/getall';
      this.callApi({ url });
    },
    async callApi({ url, data, headers }) {
      this.loading = true;
      try {
        const res = await this.$axios.get(url, data, { headers });
        this.roles = res.data;
      } catch (error) {
        console.log(error);
      }
      this.loading = false;
    },
    submit() {
      // this.$store.commit
    },
    reset() {
      this.form = { ...this.user };
    },
  },
}
</script>
