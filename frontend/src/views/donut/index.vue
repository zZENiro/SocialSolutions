<template>
  <div class="fill-height d-flex flex-column">
    <DeskTitle  subtitle="Поддержать">
      <template v-slot:title>
        Каждый может<br/>сделать доброе дело!
      </template>
    </DeskTitle>
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
