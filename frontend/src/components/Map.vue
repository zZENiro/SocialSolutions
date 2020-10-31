<template>
  <div id="map"></div>
</template>
<script>
import places from '@/mixins/places';
// import datas from '@/message.json';

export default {
  mixins: [places],
  data() {
    return {
      apiObjects: [],
    }
  },
  computed: {
    markers() {
      let markers = {
        type: "FeatureCollection",
        features: [],
      };
      if (!this.apiObjects.length) return markers;
      const features = this.apiObjects.map((task) => {
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

    document.body.style.overflow = 'hidden';

    // call api for get data
    this.getOrgs();

    // console.log(datas.Result[0]);
  },
  methods: {
    getOrgs() {
      const url = '/api/freeenv/getresult';
      const region = 'Город Первоуральск';
      const sfera = 'Иные объекты';
      const data = `{"inputsParam":'{"regnId":"66053000","regnText":"${region}","sferaId":"11","sferaText":"${sfera}","vidId":null,"vidText":null,"captionId":null,"captionText":null,"captionOsiId":null,"captionOsiText":null}'}`;
      const headers = {
        'Content-Type': 'application/json',
      };
      this.callApi({ url, data, headers });
    },
    async callApi({ url, data, headers }) {
      this.loading = true;
      try {
        const res = await this.$axios.post(url, data, { headers });
        const result = JSON.parse(res.data.d).Result;
        this.apiObjects = result;
      } catch (error) {
        console.log(error);
      }
      this.loading = false;
    },
  },
}
</script>
<style lang="scss">
  #map {
    height: 100%;
  }
</style>
