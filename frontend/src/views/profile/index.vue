<template>
  <div>
    <DeskTitle title="Ваша статистика"/>
    <v-container>
      <div class="text-h4 mt-8">Группы</div>
      <div class="row">
        <div v-for="(item, i) in [...groups, {}]" :key="i" class="col-6 col-md-4 col-lg-3">
          <SsCard :item="item" :empty="i === groups.length" />
        </div>
      </div>
      <div class="text-h4 mt-8">События</div>
      <div class="row">
        <div v-for="(item, i) in [...events, {}]" :key="i" class="col-6 col-md-4 col-lg-3">
          <SsCard :item="item" :empty="i === events.length" />
        </div>
      </div>
    </v-container>
  </div>
</template>
<script>
export default {
  data() {
    return {
      groups: [
        {
          title: 'Lorem',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Lorem 2',
          image: 'https://loremflickr.com/275/190',
        },
      ],
      events: [
        {
          title: 'Event',
          image: 'https://loremflickr.com/275/190',
        },
        {
          title: 'Event 2',
          image: 'https://loremflickr.com/275/190',
        },
      ],
    }
  },
}
</script>
<style lang="scss">
</style>
