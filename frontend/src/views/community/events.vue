<template>
  <div>
    <DeskTitle image="2" title="События" />
    <v-container>
      <v-row>
        <v-col cols="6" md="4" lg="3" v-for="(item, i) in events" :key="i">
          <SsCard :item="item"/>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      events: [
        {
          title: '«Территория ритма», 2020',
          subtitle: 'Мероприятие',
          href: '/donut/charity',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Кинопоказ «Каждый 88»',
          subtitle: 'Мероприятие',
          href: '/donut/info',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Презентация проекта «Its.we»',
          subtitle: 'Мероприятие',
          href: '/donut/deal',
          image: 'https://loremflickr.com/275/190',
        },
      ]
    }
  },
}
</script>
