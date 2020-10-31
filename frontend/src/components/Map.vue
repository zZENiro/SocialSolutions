<template>
  <div id="map"></div>
</template>
<script>
import places from '@/mixins/places';
import { mapState } from 'vuex'
// import datas from '@/message.json';

export default {
  mixins: [places],
  props: {
    organizations: Array,
  },
  data() {
    return {
      loading: false,
    }
  },
  computed: {
    ...mapState(['mapFilters']),
    markers() {
      let markers = {
        type: "FeatureCollection",
        features: [],
      };
      if (!this.organizations.length) return markers;
      const features = this.organizations.map((task) => {
        return {
          type: 'Feature',
          properties: {
            // type: task.priority,
          },
          id: task.id,
          geometry: {
            type: 'Point',
            coordinates: [
              Number.parseFloat(task.Contact.Longitude),
              Number.parseFloat(task.Contact.Latitude),
            ]
          },
        }
      })
      markers.features = features;
      return markers;
    },
  },
  watch: {
    // LatLng(latLng) {
    //   this.setPos(latLng);
    // },
    markers: {
      handler(val) {
        if ('google' in window) this.setMarkers(val);
      },
    },
  },
  mounted() {
    this.loadMapScript()
      .then(() => {
        this.initMap();
        this.setMarkers(this.markers);
        // this.initDirections();
      })
  },
}
</script>
<style lang="scss">
  #map {
    height: 100%;
  }
</style>
