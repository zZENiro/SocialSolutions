<template>
  <div>
    <DeskTitle image="3" title="Новые предложения" subtitle="Твоя возможность сделать свой город лучше" />
    <v-container>
      <v-row>
        <v-col cols="12" v-for="(item, i) in items" :key="i" >
          <v-list-item class="elevation-primary rounded-xl pl-0 align-stretch">
            <v-list-item-avatar
              class="my-0"
              size="180"
              rounded="xl"
            >
              <v-img :src="item.image" alt=""></v-img>
            </v-list-item-avatar>
            <div class="d-flex flex-column justify-space-between flex-grow-1 my-3">
              <div class="d-flex">
                <div class="title">{{ item.rating }}</div>
                <div class="title ml-2 flex-grow-1 grey--text">{{ item.votes }}</div>
                <div class="subtitle ml-2">{{ item.date }}</div>
              </div>
              <div class="title primary--text">{{ item.title }}</div>
              <div>
                <div class="subtitle">Автор: {{ item.author }}</div>
                <div class="subtitle">Регион: {{ item.region }}</div>
              </div>
            </div>
          </v-list-item>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      items: [
        {
          title: 'Создание единой площадки its.we  решения проблемы отсутствия сервиса для людей с ОВЗ',
          rating: '9.9/10',
          votes: '10 785 проголосовавших',
          date: '01.11.2020',
          author: 'Social Solutions',
          region: 'Екатеринбург',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Разделить транспортные средства на «общие» и «предназначенные для перевозки инвалидов»',
          rating: '3.2/10',
          votes: '1785 проголосовавших',
          date: '28.10.2020',
          author: 'Social Solutions',
          region: 'Пермь',
          image: 'https://loremflickr.com/275/190',
        },
      ],
    }
  },
}
</script>
