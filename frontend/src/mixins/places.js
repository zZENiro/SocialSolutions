const places = {
  data() {
    return {
      googleApis: {
        API_KEY: process.env.VUE_APP_GAPI_KEY,
        autocompleteService: null,
        predictions: null,
        sessionToken: null,
        loading: false,
        map: null,
        LatLng: {lat: 56.8119915, lng: 60.4772995},
        markers: {
          "type": "FeatureCollection",
          "features": [],
        },
        taskColorMap: {
          'A': 'c00',
          'B': 'dd0',
          'C': '00c',
          'D': '555',
        },
        directionsService: null,
        directionsRenderer: null,
        minZoomLevel: 8,
      },
    }
  },
  methods: {
    async loadMapScript() {
      return new Promise((res) => {
        // MAP API
        if ('google' in window) return res();
        if (!('loadingGoogleEvent' in window)) {
          window.loadingGoogleEvent = new Event('googleLoaded');
          var mapScript = document.createElement('script');
          mapScript.type = 'text/javascript';
          mapScript.defer = true;
          mapScript.src = `https://maps.googleapis.com/maps/api/js?key=${this.googleApis.API_KEY}&libraries=places`;
          mapScript.onload = () => {
            console.log('google map script loaded');
            document.dispatchEvent(window.loadingGoogleEvent);
          };
          document.body.appendChild(mapScript);
        }
        document.addEventListener('googleLoaded', () => {
          return res();
        });
      });
    },
    initMapPlaces() {
      console.log('init places map api');
      // Create a new session token.
      this.$set(this.googleApis, 'sessionToken', new window.google.maps.places.AutocompleteSessionToken());

      // Pass the token to the autocomplete service.
      this.$set(this.googleApis, 'autocompleteService', new window.google.maps.places.AutocompleteService());
    },
    initMap() {
      console.log('init map api');
      const map = new window.google.maps.Map(
        document.getElementById("map"),
        {
          zoom: 8,
          center: this.googleApis.LatLng,
        }
      );
      this.$set(this.googleApis, 'map', map);

      // event handling
      map.data.addListener("click", event => {
        this.$emit('google.data.click', event);
      });
    },
    initDirections() {
      // init directions API
      console.log('init directions api');
      this.$set(this.googleApis, 'directionsService', new window.google.maps.DirectionsService());
      this.$set(this.googleApis, 'directionsRenderer', new window.google.maps.DirectionsRenderer({
        suppressMarkers: true,
      }));
      this.googleApis.directionsRenderer.setMap(this.googleApis.map);
    },
    searchPlaces(input) {
      this.$set(this.googleApis, 'loading', true);
      this.googleApis.autocompleteService.getPlacePredictions(
        {
          input,
          sessionToken: this.googleApis.sessionToken,
          types: ['geocode'],
        },
        (predictions, status) => {
          if (status === 'OK') {
            this.$set(this.googleApis, 'predictions', predictions);
          }
          this.$set(this.googleApis, 'loading', false);
        },
      );
    },
    async getLonLat(placeId) {
      // convert place_id to lon lat
      return new Promise((res) => {
        const geocoder = new window.google.maps.Geocoder();
        let lonLat = {
          longitude: '',
          latitude: '',
        };
        geocoder.geocode({ placeId }, (results, status) => {
          if (status === "OK") {
            lonLat = {
              longitude: results[0].geometry.location.lng(),
              latitude: results[0].geometry.location.lat(),
            }
          }
          return res(lonLat);
        });
      })
    },
    async getLocation(placeId) {
      return new Promise((res) => {
        const geocoder = new window.google.maps.Geocoder();
        geocoder.geocode({ placeId }, (results, status) => {
          let location = null;
          if (status === "OK") {
            location = results[0].geometry.location;
          }
          return res(location);
        });
      })
    },
    setPos(latLng) {
      this.googleApis.map.panTo(latLng);
    },
    setMarkers(markers) {
      // remove old
      this.googleApis.map?.data?.forEach((feature) => {
        const oldFeatureId = feature.getId();
        const hasOld = markers.features.some((el) => {
          return Number.parseInt(oldFeatureId) === Number.parseInt(el.id)
        })
        // if map contain old marker, then remove it
        if (!hasOld) {
          this.googleApis.map.data.remove(feature);
        }
      })
      
      // add new
      markers.features.forEach((feature) => {
        const Feature = new window.google.maps.Data.Feature({
          id: feature.id,
          properties: feature.properties,
          geometry: {
            lat: feature.geometry.coordinates[1],
            lng: feature.geometry.coordinates[0],
          },
        });
        // if map not contain marker
        if (!this.googleApis.map.data.contains(this.googleApis.map.data.getFeatureById(feature.id))) {
          this.googleApis.map.data.add(Feature);
        }
      });

      // coloring
      this.googleApis.map.data.setStyle((feature) => {
        const text = feature.getProperty('text') || '';
        const color = feature.getProperty('color') || '0075FF';
        const icon = feature.getProperty('icon') || '';
        return {
          icon: { url: `https://cdn.mapmarker.io/api/v1/pin?size=190&text=${text}&icon=${icon}&size=40&background=${color}&color=FFF&hoffset=-1` }
        };
      });

      if (markers.features.length) this.zoom();
    },
    zoom() {
      // zoom to show all features in map on screen
      const bounds = new window.google.maps.LatLngBounds();
      this.googleApis.map.data.forEach((feature) => {
        this.processPoints(feature.getGeometry(), bounds.extend, bounds);
      });
      this.googleApis.map.fitBounds(bounds);
      const zoom = this.googleApis.map.getZoom();
      this.googleApis.map.setZoom(zoom > 8 ? 8 : zoom);
    },
    processPoints(geometry, callback, thisArg) {
      /**
       * Process each point in a Geometry, regardless of how deep the points may lie.
       * @param {google.maps.Data.Geometry} geometry The structure to process
       * @param {function(google.maps.LatLng)} callback A function to call on each
       *     LatLng point encountered (e.g. Array.push)
       * @param {Object} thisArg The value of 'this' as provided to 'callback' (e.g.
       *     myArray)
       */
      if (geometry instanceof window.google.maps.LatLng) {
        callback.call(thisArg, geometry);
      } else if (geometry instanceof window.google.maps.Data.Point) {
        callback.call(thisArg, geometry.get());
      } else {
        geometry.getArray().forEach(function(g) {
          this.processPoints(g, callback, thisArg);
        });
      }
    },
    panTo(task) {
      // pan to task
      const lat = task.station.latitude;
      const lng = task.station.longitude;
      this.googleApis.map.panTo({ lat, lng });
    },
    async calcRoute({start, end, tasks, optimized}) {
      /* calc route 
       * @start, @end = Object{lat: String, lng: String}
       * @tasks = Array<task>
       * @optimized = Boolean
      */
      return new Promise((res) => {
        let info = {};
        let order = [];
        let link = '';
        const waypoints = tasks.map((el) => {
          const lat = Number.parseFloat(el.station.latitude);
          const lng = Number.parseFloat(el.station.longitude);
          return {
            location: new window.google.maps.LatLng({lat, lng}),
            stopover: true,
          }
        });
        var request = {
          origin: start,
          destination: end,
          waypoints,
          optimizeWaypoints: !!optimized,
          provideRouteAlternatives: true,
          travelMode: 'DRIVING'
        };
        this.googleApis.directionsService.route(request, (result, status) => {
          if (status == 'OK') {
            this.googleApis.directionsRenderer.setDirections(result);
            info = result.routes[0].legs;
            order = result.routes[0].waypoint_order;
            link = this.buildLink(info);
          }
          return res({ info: [...info], order, link });
        });
      });
    },
    buildLink(legs) {
      let link = `https://www.google.com/maps/dir/?api=1&travelmode=driving&origin=${encodeURI(legs[0].start_address)}&waypoints=`;

      for (let i = 0; i < legs.length - 1; i++) {
        link += encodeURI(legs[i].end_address);
        (i < legs.length - 2) ? link += "|" : null;
      }

      link += `&destination=${encodeURI(legs[legs.length-1].end_address)}`;
      return link;
    },
  },
};

export default places
