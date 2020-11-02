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
            title: task.Caption_small,
            phone: task.Contact?.Phone,
            // text: 'dfg',
            icon: 'fa-star'
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

    // handle event
    this.$on('google.data.click', (feature) => {
      const title = feature.feature.getProperty('title');
      const phone = feature.feature.getProperty('phone');
      const content = `
        <div style="padding:1rem;">
          <div class="title">
            ${title}
          </div>
          <div class="subtitle mt-3">
            ${phone}
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
