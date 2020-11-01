<template>
  <div>
    <DeskTitle image="3" title="Новости" subtitle="Самые последние события в мире инклюзии, науки" />
    <v-container>
      <v-row>
        <v-col cols="12" v-for="(item, i) in items" :key="i" >
          <v-list-item class="elevation-primary rounded-xl pr-0 align-stretch">
            <div class="d-flex flex-column justify-space-between flex-grow-1 my-3">
              <div class="title">{{ item.tag }}</div>
              <div class="title primary--text">{{ item.title }}</div>
              <div class="subtitle">Автор: {{ item.author }}</div>
              <div class="subtitle">{{ item.date }}</div>
            </div>
            <v-list-item-avatar
              class="my-0"
              size="180"
              rounded="xl"
            >
              <v-img :src="item.image" alt=""></v-img>
            </v-list-item-avatar>
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
          title: 'На уральском хакатоне команда молодых Social Solutions создала инновационную онлайн-площадку для людей с ОВЗ',
          tag: '#лайфхаки',
          date: '01.11.2020',
          author: 'Social Solutions',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'В Волгограде реабилитация детей-инвалидов будет проводиться с участием специально обученных собак',
          tag: '#добраяистория ',
          date: '28.10.2020',
          author: 'Social Solutions',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Молодых людей с инвалидностью приглашают на бесплатные онлайн-курсы литературного мастерства',
          tag: '#добраяистория ',
          date: '28.10.2020',
          author: 'Social Solutions',
          image: 'https://loremflickr.com/275/190',
        },
      ],
    }
  },
}
</script>
