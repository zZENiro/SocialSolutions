<template>
  <v-container fluid fill-height pa-0 class="flex-column">
    <div style="flex:1;width:100%;">
      <Map />
    </div>
  </v-container>
</template>
<script>
import Map from '@/components/Map.vue';

export default {
  components: {
    Map,
  },
  metaInfo() {
    return {
      meta: [
        // { name: 'viewport', content: 'width=device-width, initial-scale=1.0, user-scalable=no' },
      ],
    };
  },
}
</script>
