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
    bbox: Array,
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
      markers.features = this.organizations.map((ft) => ({
        ...ft,
        geomerty: {
          ...ft.geometry,
          coordinates: ft.geometry.coordinates.reverse(),
        },
      }));
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
    'googleApis.bbox'(val) {
      this.$emit('update:bbox', val);
    },
  },
  mounted() {
    this.loadMapScript()
      .then(() => {
        this.initMap();
        this.setMarkers(this.markers);
        // this.initDirections();
      })

    // handle event
    this.$on('google.data.click', (feature) => {
      const data = feature.feature.getProperty('data');
      const coord = [];
      feature.feature.getGeometry().forEachLatLng((LatLng) => coord.push(LatLng.toString()));
      const { name, address } = data;
      const content = `
        <div style="padding:1rem;">
          <div class="title">
            ${name}
          </div>
          <div class="subtitle mt-3">
            ${address}
          </div>
          <div class="subtitle mt-3">
            ${coord.join(' ')}
          </div>
        </div>
      `;
      const infowindow = new window.google.maps.InfoWindow({
        content,
      });
      infowindow.setPosition(feature.latLng);
      infowindow.open(this.googleApis.map, new window.google.maps.MVCObject());
    })
  },
}
</script>
<style lang="scss">
  #map {
    height: 100%;
  }
</style>
