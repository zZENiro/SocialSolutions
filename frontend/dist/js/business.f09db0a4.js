(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["business"],{"1da1":function(t,e,n){"use strict";n.d(e,"a",(function(){return o}));n("d3b7");function r(t,e,n,r,o,i,a){try{var s=t[i](a),c=s.value}catch(u){return void n(u)}s.done?e(c):Promise.resolve(c).then(r,o)}function o(t){return function(){var e=this,n=arguments;return new Promise((function(o,i){var a=t.apply(e,n);function s(t){r(a,o,i,s,c,"next",t)}function c(t){r(a,o,i,s,c,"throw",t)}s(void 0)}))}}},2040:function(t,e,n){},"25eb":function(t,e,n){var r=n("23e7"),o=n("c20d");r({target:"Number",stat:!0,forced:Number.parseInt!=o},{parseInt:o})},3321:function(t,e,n){"use strict";n("2040")},"6aab":function(t,e,n){"use strict";n.r(e);var r=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("v-container",{staticClass:"flex-column",class:{"map-loading":t.loading},attrs:{fluid:"","fill-height":"","pa-0":""}},[n("transition",{attrs:{name:"fade",mode:"out-in",tag:"div"}},[t.mapList?n("v-container",{key:2},[n("div",{staticClass:"text-h3 my-6 my-sm-12 ml-3"},[t._v("Список объектов")]),n("v-list",[t._l(t.organizations,(function(e,r){return[n("v-list-item",{key:r,attrs:{"three-line":""}},[n("v-list-item-content",[n("v-list-item-title",[t._v(t._s(e.Caption))]),n("v-list-item-subtitle",[t._v("Адрес: "+t._s(e.Contact.Address))]),n("v-list-item-subtitle",[t._v("Телефон: "+t._s(e.Contact.Phone))])],1),n("v-list-item-action",[n("div",{staticClass:"d-flex"},[t._l(e.Dostup,(function(r,o){return[2===e.Dostup[o]?n("v-icon",{key:o,staticClass:"ml-3",attrs:{color:"success"}},[t._v(t._s(t.mapIcons[o]))]):t._e()]}))],2)])],1),n("v-divider",{key:"divider-"+r})]}))],2)],1):n("div",{key:1,staticStyle:{flex:"1","min-width":"100%"}},[n("Map",{attrs:{organizations:t.organizations}})],1)],1)],1)},o=[],i=(n("99af"),n("96cf"),n("1da1")),a=n("5530"),s=function(){var t=this,e=t.$createElement,n=t._self._c||e;return n("div",{attrs:{id:"map"}})},c=[],u=(n("d81d"),n("a9e3"),n("c35a"),n("4160"),n("45fc"),n("25eb"),n("d3b7"),n("159b"),n("2909")),l={data:function(){return{googleApis:{API_KEY:"AIzaSyAxu1PqQlh8psyP0hmahMdc6uWkspPi_JI",autocompleteService:null,predictions:null,sessionToken:null,loading:!1,map:null,LatLng:{lat:56.8119915,lng:60.4772995},markers:{type:"FeatureCollection",features:[]},taskColorMap:{A:"c00",B:"dd0",C:"00c",D:"555"},directionsService:null,directionsRenderer:null,minZoomLevel:8}}},methods:{loadMapScript:function(){var t=this;return Object(i["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.abrupt("return",new Promise((function(e){if("google"in window)return e();if(!("loadingGoogleEvent"in window)){window.loadingGoogleEvent=new Event("googleLoaded");var n=document.createElement("script");n.type="text/javascript",n.defer=!0,n.src="https://maps.googleapis.com/maps/api/js?key=".concat(t.googleApis.API_KEY,"&libraries=places"),n.onload=function(){console.log("google map script loaded"),document.dispatchEvent(window.loadingGoogleEvent)},document.body.appendChild(n)}document.addEventListener("googleLoaded",(function(){return e()}))})));case 1:case"end":return e.stop()}}),e)})))()},initMapPlaces:function(){console.log("init places map api"),this.$set(this.googleApis,"sessionToken",new window.google.maps.places.AutocompleteSessionToken),this.$set(this.googleApis,"autocompleteService",new window.google.maps.places.AutocompleteService)},initMap:function(){var t=this;console.log("init map api");var e=new window.google.maps.Map(document.getElementById("map"),{zoom:8,center:this.googleApis.LatLng});this.$set(this.googleApis,"map",e),e.data.addListener("click",(function(e){t.$emit("google.data.click",e.feature)}))},initDirections:function(){console.log("init directions api"),this.$set(this.googleApis,"directionsService",new window.google.maps.DirectionsService),this.$set(this.googleApis,"directionsRenderer",new window.google.maps.DirectionsRenderer({suppressMarkers:!0})),this.googleApis.directionsRenderer.setMap(this.googleApis.map)},searchPlaces:function(t){var e=this;this.$set(this.googleApis,"loading",!0),this.googleApis.autocompleteService.getPlacePredictions({input:t,sessionToken:this.googleApis.sessionToken,types:["geocode"]},(function(t,n){"OK"===n&&e.$set(e.googleApis,"predictions",t),e.$set(e.googleApis,"loading",!1)}))},getLonLat:function(t){return Object(i["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.abrupt("return",new Promise((function(e){var n=new window.google.maps.Geocoder,r={longitude:"",latitude:""};n.geocode({placeId:t},(function(t,n){return"OK"===n&&(r={longitude:t[0].geometry.location.lng(),latitude:t[0].geometry.location.lat()}),e(r)}))})));case 1:case"end":return e.stop()}}),e)})))()},getLocation:function(t){return Object(i["a"])(regeneratorRuntime.mark((function e(){return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return e.abrupt("return",new Promise((function(e){var n=new window.google.maps.Geocoder;n.geocode({placeId:t},(function(t,n){var r=null;return"OK"===n&&(r=t[0].geometry.location),e(r)}))})));case 1:case"end":return e.stop()}}),e)})))()},setPos:function(t){this.googleApis.map.panTo(t)},setMarkers:function(t){var e,n,r=this;null===(e=this.googleApis.map)||void 0===e||null===(n=e.data)||void 0===n||n.forEach((function(e){var n=e.getId(),o=t.features.some((function(t){return Number.parseInt(n)===Number.parseInt(t.id)}));o||r.googleApis.map.data.remove(e)})),t.features.forEach((function(t){var e=new window.google.maps.Data.Feature({id:t.id,properties:t.properties,geometry:{lat:t.geometry.coordinates[1],lng:t.geometry.coordinates[0]}});r.googleApis.map.data.contains(r.googleApis.map.data.getFeatureById(t.id))||r.googleApis.map.data.add(e)})),this.googleApis.map.data.setStyle((function(t){var e=t.getProperty("type")||"",n="".concat(r.googleApis.taskColorMap[e]||"555");return{icon:{url:"https://cdn.mapmarker.io/api/v1/font-awesome/v5/pin?text=".concat(e,"&size=40&background=").concat(n,"&color=FFF&hoffset=-1")}}})),t.features.length&&this.zoom()},zoom:function(){var t=this,e=new window.google.maps.LatLngBounds;this.googleApis.map.data.forEach((function(n){t.processPoints(n.getGeometry(),e.extend,e)})),this.googleApis.map.fitBounds(e);var n=this.googleApis.map.getZoom();this.googleApis.map.setZoom(n>8?8:n)},processPoints:function(t,e,n){t instanceof window.google.maps.LatLng?e.call(n,t):t instanceof window.google.maps.Data.Point?e.call(n,t.get()):t.getArray().forEach((function(t){this.processPoints(t,e,n)}))},panTo:function(t){var e=t.station.latitude,n=t.station.longitude;this.googleApis.map.panTo({lat:e,lng:n})},calcRoute:function(t){var e=this;return Object(i["a"])(regeneratorRuntime.mark((function n(){var r,o,i,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=t.start,o=t.end,i=t.tasks,a=t.optimized,n.abrupt("return",new Promise((function(t){var n={},s=[],c="",l=i.map((function(t){var e=Number.parseFloat(t.station.latitude),n=Number.parseFloat(t.station.longitude);return{location:new window.google.maps.LatLng({lat:e,lng:n}),stopover:!0}})),p={origin:r,destination:o,waypoints:l,optimizeWaypoints:!!a,provideRouteAlternatives:!0,travelMode:"DRIVING"};e.googleApis.directionsService.route(p,(function(r,o){return"OK"==o&&(e.googleApis.directionsRenderer.setDirections(r),n=r.routes[0].legs,s=r.routes[0].waypoint_order,c=e.buildLink(n)),t({info:Object(u["a"])(n),order:s,link:c})}))})));case 2:case"end":return n.stop()}}),n)})))()},buildLink:function(t){for(var e="https://www.google.com/maps/dir/?api=1&travelmode=driving&origin=".concat(encodeURI(t[0].start_address),"&waypoints="),n=0;n<t.length-1;n++)e+=encodeURI(t[n].end_address),n<t.length-2&&(e+="|");return e+="&destination=".concat(encodeURI(t[t.length-1].end_address)),e}}},p=l,d=n("2f62"),g={mixins:[p],props:{organizations:Array},data:function(){return{loading:!1}},computed:Object(a["a"])(Object(a["a"])({},Object(d["b"])(["mapFilters"])),{},{markers:function(){var t={type:"FeatureCollection",features:[]};if(!this.organizations.length)return t;var e=this.organizations.map((function(t){return{type:"Feature",properties:{},id:t.id,geometry:{type:"Point",coordinates:[Number.parseFloat(t.Contact.Longitude),Number.parseFloat(t.Contact.Latitude)]}}}));return t.features=e,t}}),watch:{markers:{handler:function(t){"google"in window&&this.setMarkers(t)}}},mounted:function(){var t=this;this.loadMapScript().then((function(){t.initMap(),t.setMarkers(t.markers)}))}},f=g,h=(n("894b"),n("2877")),m=Object(h["a"])(f,s,c,!1,null,null,null),v=m.exports,w={components:{Map:v},data:function(){return{organizations:[],loading:!1,mapIcons:{Dost_Kolyas:"mdi-wheelchair-accessibility",Dost_ODA:"mdi-human-cane",Dost_Sluh:"mdi-ear-hearing-off",Dost_Um:"mdi-brain",Dost_Zren:"mdi-eye-off"}}},computed:Object(a["a"])({},Object(d["b"])(["mapList","mapFilters"])),watch:{mapFilters:{deep:!0,handler:function(){this.getOrgs()}}},metaInfo:function(){return{meta:[]}},mounted:function(){this.getOrgs()},methods:{getOrgs:function(){var t=this;return Object(i["a"])(regeneratorRuntime.mark((function e(){var n,r,o,i,a;return regeneratorRuntime.wrap((function(e){while(1)switch(e.prev=e.next){case 0:return n="/api/freeenv/getresult",r=t.mapFilters.region,o=t.mapFilters.sfera,i='{"inputsParam":\'{"regnId":"66053000","regnText":"'.concat(r,'","sferaId":"11","sferaText":"').concat(o,'","vidId":null,"vidText":null,"captionId":null,"captionText":null,"captionOsiId":null,"captionOsiText":null}\'}'),a={"Content-Type":"application/json"},e.next=7,t.callApi({url:n,data:i,headers:a});case 7:case"end":return e.stop()}}),e)})))()},callApi:function(t){var e=this;return Object(i["a"])(regeneratorRuntime.mark((function n(){var r,o,i,a,s;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=t.url,o=t.data,i=t.headers,e.loading=!0,n.prev=2,n.next=5,e.$axios.post(r,o,{headers:i});case 5:a=n.sent,s=JSON.parse(a.data.d).Result,e.organizations=s,n.next=13;break;case 10:n.prev=10,n.t0=n["catch"](2),console.log(n.t0);case 13:e.loading=!1;case 14:case"end":return n.stop()}}),n,null,[[2,10]])})))()}}},y=w,b=(n("3321"),n("6544")),L=n.n(b),x=n("a523"),A=n("ce7e"),k=n("132d"),_=n("8860"),E=n("da13"),O=n("1800"),I=n("5d23"),P=Object(h["a"])(y,r,o,!1,null,null,null);e["default"]=P.exports;L()(P,{VContainer:x["a"],VDivider:A["a"],VIcon:k["a"],VList:_["a"],VListItem:E["a"],VListItemAction:O["a"],VListItemContent:I["a"],VListItemSubtitle:I["b"],VListItemTitle:I["c"]})},"7e12":function(t,e,n){var r=n("da84"),o=n("58a8").trim,i=n("5899"),a=r.parseFloat,s=1/a(i+"-0")!==-1/0;t.exports=s?function(t){var e=o(String(t)),n=a(e);return 0===n&&"-"==e.charAt(0)?-0:n}:a},"894b":function(t,e,n){"use strict";n("a8f9")},"96cf":function(t,e,n){var r=function(t){"use strict";var e,n=Object.prototype,r=n.hasOwnProperty,o="function"===typeof Symbol?Symbol:{},i=o.iterator||"@@iterator",a=o.asyncIterator||"@@asyncIterator",s=o.toStringTag||"@@toStringTag";function c(t,e,n){return Object.defineProperty(t,e,{value:n,enumerable:!0,configurable:!0,writable:!0}),t[e]}try{c({},"")}catch(R){c=function(t,e,n){return t[e]=n}}function u(t,e,n,r){var o=e&&e.prototype instanceof m?e:m,i=Object.create(o.prototype),a=new P(r||[]);return i._invoke=_(t,n,a),i}function l(t,e,n){try{return{type:"normal",arg:t.call(e,n)}}catch(R){return{type:"throw",arg:R}}}t.wrap=u;var p="suspendedStart",d="suspendedYield",g="executing",f="completed",h={};function m(){}function v(){}function w(){}var y={};y[i]=function(){return this};var b=Object.getPrototypeOf,L=b&&b(b(j([])));L&&L!==n&&r.call(L,i)&&(y=L);var x=w.prototype=m.prototype=Object.create(y);function A(t){["next","throw","return"].forEach((function(e){c(t,e,(function(t){return this._invoke(e,t)}))}))}function k(t,e){function n(o,i,a,s){var c=l(t[o],t,i);if("throw"!==c.type){var u=c.arg,p=u.value;return p&&"object"===typeof p&&r.call(p,"__await")?e.resolve(p.__await).then((function(t){n("next",t,a,s)}),(function(t){n("throw",t,a,s)})):e.resolve(p).then((function(t){u.value=t,a(u)}),(function(t){return n("throw",t,a,s)}))}s(c.arg)}var o;function i(t,r){function i(){return new e((function(e,o){n(t,r,e,o)}))}return o=o?o.then(i,i):i()}this._invoke=i}function _(t,e,n){var r=p;return function(o,i){if(r===g)throw new Error("Generator is already running");if(r===f){if("throw"===o)throw i;return F()}n.method=o,n.arg=i;while(1){var a=n.delegate;if(a){var s=E(a,n);if(s){if(s===h)continue;return s}}if("next"===n.method)n.sent=n._sent=n.arg;else if("throw"===n.method){if(r===p)throw r=f,n.arg;n.dispatchException(n.arg)}else"return"===n.method&&n.abrupt("return",n.arg);r=g;var c=l(t,e,n);if("normal"===c.type){if(r=n.done?f:d,c.arg===h)continue;return{value:c.arg,done:n.done}}"throw"===c.type&&(r=f,n.method="throw",n.arg=c.arg)}}}function E(t,n){var r=t.iterator[n.method];if(r===e){if(n.delegate=null,"throw"===n.method){if(t.iterator["return"]&&(n.method="return",n.arg=e,E(t,n),"throw"===n.method))return h;n.method="throw",n.arg=new TypeError("The iterator does not provide a 'throw' method")}return h}var o=l(r,t.iterator,n.arg);if("throw"===o.type)return n.method="throw",n.arg=o.arg,n.delegate=null,h;var i=o.arg;return i?i.done?(n[t.resultName]=i.value,n.next=t.nextLoc,"return"!==n.method&&(n.method="next",n.arg=e),n.delegate=null,h):i:(n.method="throw",n.arg=new TypeError("iterator result is not an object"),n.delegate=null,h)}function O(t){var e={tryLoc:t[0]};1 in t&&(e.catchLoc=t[1]),2 in t&&(e.finallyLoc=t[2],e.afterLoc=t[3]),this.tryEntries.push(e)}function I(t){var e=t.completion||{};e.type="normal",delete e.arg,t.completion=e}function P(t){this.tryEntries=[{tryLoc:"root"}],t.forEach(O,this),this.reset(!0)}function j(t){if(t){var n=t[i];if(n)return n.call(t);if("function"===typeof t.next)return t;if(!isNaN(t.length)){var o=-1,a=function n(){while(++o<t.length)if(r.call(t,o))return n.value=t[o],n.done=!1,n;return n.value=e,n.done=!0,n};return a.next=a}}return{next:F}}function F(){return{value:e,done:!0}}return v.prototype=x.constructor=w,w.constructor=v,v.displayName=c(w,s,"GeneratorFunction"),t.isGeneratorFunction=function(t){var e="function"===typeof t&&t.constructor;return!!e&&(e===v||"GeneratorFunction"===(e.displayName||e.name))},t.mark=function(t){return Object.setPrototypeOf?Object.setPrototypeOf(t,w):(t.__proto__=w,c(t,s,"GeneratorFunction")),t.prototype=Object.create(x),t},t.awrap=function(t){return{__await:t}},A(k.prototype),k.prototype[a]=function(){return this},t.AsyncIterator=k,t.async=function(e,n,r,o,i){void 0===i&&(i=Promise);var a=new k(u(e,n,r,o),i);return t.isGeneratorFunction(n)?a:a.next().then((function(t){return t.done?t.value:a.next()}))},A(x),c(x,s,"Generator"),x[i]=function(){return this},x.toString=function(){return"[object Generator]"},t.keys=function(t){var e=[];for(var n in t)e.push(n);return e.reverse(),function n(){while(e.length){var r=e.pop();if(r in t)return n.value=r,n.done=!1,n}return n.done=!0,n}},t.values=j,P.prototype={constructor:P,reset:function(t){if(this.prev=0,this.next=0,this.sent=this._sent=e,this.done=!1,this.delegate=null,this.method="next",this.arg=e,this.tryEntries.forEach(I),!t)for(var n in this)"t"===n.charAt(0)&&r.call(this,n)&&!isNaN(+n.slice(1))&&(this[n]=e)},stop:function(){this.done=!0;var t=this.tryEntries[0],e=t.completion;if("throw"===e.type)throw e.arg;return this.rval},dispatchException:function(t){if(this.done)throw t;var n=this;function o(r,o){return s.type="throw",s.arg=t,n.next=r,o&&(n.method="next",n.arg=e),!!o}for(var i=this.tryEntries.length-1;i>=0;--i){var a=this.tryEntries[i],s=a.completion;if("root"===a.tryLoc)return o("end");if(a.tryLoc<=this.prev){var c=r.call(a,"catchLoc"),u=r.call(a,"finallyLoc");if(c&&u){if(this.prev<a.catchLoc)return o(a.catchLoc,!0);if(this.prev<a.finallyLoc)return o(a.finallyLoc)}else if(c){if(this.prev<a.catchLoc)return o(a.catchLoc,!0)}else{if(!u)throw new Error("try statement without catch or finally");if(this.prev<a.finallyLoc)return o(a.finallyLoc)}}}},abrupt:function(t,e){for(var n=this.tryEntries.length-1;n>=0;--n){var o=this.tryEntries[n];if(o.tryLoc<=this.prev&&r.call(o,"finallyLoc")&&this.prev<o.finallyLoc){var i=o;break}}i&&("break"===t||"continue"===t)&&i.tryLoc<=e&&e<=i.finallyLoc&&(i=null);var a=i?i.completion:{};return a.type=t,a.arg=e,i?(this.method="next",this.next=i.finallyLoc,h):this.complete(a)},complete:function(t,e){if("throw"===t.type)throw t.arg;return"break"===t.type||"continue"===t.type?this.next=t.arg:"return"===t.type?(this.rval=this.arg=t.arg,this.method="return",this.next="end"):"normal"===t.type&&e&&(this.next=e),h},finish:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.finallyLoc===t)return this.complete(n.completion,n.afterLoc),I(n),h}},catch:function(t){for(var e=this.tryEntries.length-1;e>=0;--e){var n=this.tryEntries[e];if(n.tryLoc===t){var r=n.completion;if("throw"===r.type){var o=r.arg;I(n)}return o}}throw new Error("illegal catch attempt")},delegateYield:function(t,n,r){return this.delegate={iterator:j(t),resultName:n,nextLoc:r},"next"===this.method&&(this.arg=e),h}},t}(t.exports);try{regeneratorRuntime=r}catch(o){Function("r","regeneratorRuntime = r")(r)}},a8f9:function(t,e,n){},c20d:function(t,e,n){var r=n("da84"),o=n("58a8").trim,i=n("5899"),a=r.parseInt,s=/^[+-]?0[Xx]/,c=8!==a(i+"08")||22!==a(i+"0x16");t.exports=c?function(t,e){var n=o(String(t));return a(n,e>>>0||(s.test(n)?16:10))}:a},c35a:function(t,e,n){var r=n("23e7"),o=n("7e12");r({target:"Number",stat:!0,forced:Number.parseFloat!=o},{parseFloat:o})}}]);
//# sourceMappingURL=business.f09db0a4.js.map