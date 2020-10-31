<template>
  <v-container py-6 py-sm-12>
    <v-row>
      <v-col>
        <div class="text-h3">Перевод средств<br/>в благотворительный фонд</div>
        <v-row>
          <v-col cols="12" sm="6">
            <form @submit.prevent="send" class="mt-6 mt-sm-12">
              <v-text-field
                v-model="fond"
                label="Фонд"
                outlined
                rounded
                :hide-details="'auto'"
              ></v-text-field>
              <v-text-field
                v-model="sum"
                label="Сумма"
                class="mt-3"
                outlined
                rounded
                :hide-details="'auto'"
              ></v-text-field>
              <v-text-field
                v-model="name"
                label="Ваше имя"
                class="mt-3"
                outlined
                rounded
                :hide-details="'auto'"
              ></v-text-field>
              <v-btn color="primary" rounded class="mt-3" block x-large type="submit">Отправить</v-btn>
            </form>
          </v-col>
        </v-row>
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      fond: '',
      sum: '',
      name: '',
    }
  },
  methods: {
    send() {
      console.log('send');
    },
  },
}
</script>
