<template>
  <div class="fill-height d-flex flex-column">
    <div class="grey lighten-3">
      <v-container class="secondary--text">
        <div class="text-h4 text-sm-h3 my-6 my-sm-12">
          Каждый может<br/>сделать доброе дело!
        </div>
        <div class="text-h5 my-3">Поддержать</div>
      </v-container>
    </div>
    <v-container class="flex-grow-1 d-flex align-center">
      <v-row class="justify-center">
        <v-col cols="12" sm="8" class="d-flex justify-space-around">
          <SsCard class="mx-2" v-for="(item, i) in donuts" :key="i" :item="item" />
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      donuts: [
        {
          title: 'Финансово',
          href: '/donut/charity',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Информационно',
          href: '/donut/info',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Делом',
          href: '/donut/deal',
          image: 'https://loremflickr.com/275/190',
        },
      ],
    }
  },
}
</script>
