<template>
  <v-container>
    <div class="text-h3 my-12">Столько возможнестей!</div>
    <v-row>
      <v-col cols="12" sm="6">
        <div class="text-h5">Помочь как волотёр</div>
        <SsCard class="mt-6" :item="item" />
      </v-col>
      <v-col cols="12" sm="6">
        <div class="text-h5">Помочь как профессионал</div>
        <SsCard class="mt-6" :item="item" />
      </v-col>
    </v-row>
  </v-container>
</template>
<script>
export default {
  data() {
    return {
      item: {
        title: 'Post',
        image: 'https://loremflickr.com/275/190',
      },
    }
  },
}
</script>
