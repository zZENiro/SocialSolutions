(window["webpackJsonp"]=window["webpackJsonp"]||[]).push([["settings"],{"7fcb":function(e,t,a){"use strict";a.r(t);var n=function(){var e=this,t=e.$createElement,a=e._self._c||t;return a("div",[a("DeskTitle",{scopedSlots:e._u([{key:"title",fn:function(){return[a("div",[e._v("Настройки")]),a("div",{staticClass:"row no-gutters align-center mt-6"},[a("div",{staticClass:"text-h5 mr-3 col-auto"},[e._v("Я: ")]),a("v-select",{staticClass:"col col-md-auto",attrs:{items:e.roles,value:e.role,label:"Ваша роль на сайте","item-text":"name","item-id":"name",outlined:"",rounded:"","return-object":"","hide-details":"auto",loading:e.loading,disabled:e.loading},on:{change:function(t){return e.$store.dispatch("setRole",t)}}})],1)]},proxy:!0}])}),a("v-container",[a("v-row",[a("v-col",[a("form",{on:{submit:function(t){return t.preventDefault(),e.submit(t)}}},[a("v-row",[a("v-col",{staticClass:"d-flex align-center",attrs:{cols:"12",md:"6"}},[a("v-text-field",{attrs:{label:"Имя",outlined:"",rounded:"","hide-details":"auto"},model:{value:e.form.name,callback:function(t){e.$set(e.form,"name",t)},expression:"form.name"}})],1),a("v-col",{staticClass:"d-flex align-center",attrs:{cols:"12",md:"6"}},[a("v-text-field",{attrs:{label:"Фамилия",outlined:"",rounded:"","hide-details":"auto"},model:{value:e.form.secondName,callback:function(t){e.$set(e.form,"secondName",t)},expression:"form.secondName"}})],1)],1),a("div",{staticClass:"d-flex mt-3"},[a("v-btn",{attrs:{color:"primary",depressed:"",rounded:"","x-large":"",type:"submit"},on:{click:e.submit}},[e._v("Применить")]),a("v-btn",{staticClass:"ml-3",attrs:{type:"button",color:"primary",rounded:"",outlined:"","x-large":""},on:{click:e.reset}},[e._v("Сбросить")])],1)],1)])],1)],1)],1)},o=[],r=(a("96cf"),a("1da1")),s=a("5530"),l=a("2f62"),i={data:function(){return{form:{role:""},roles:[],loading:!1}},computed:Object(s["a"])({},Object(l["c"])(["user","role"])),mounted:function(){this.getRoles(),this.reset()},methods:{getRoles:function(){var e="/api/roles/getall";this.callApi({url:e})},callApi:function(e){var t=this;return Object(r["a"])(regeneratorRuntime.mark((function a(){var n,o,r,s;return regeneratorRuntime.wrap((function(a){while(1)switch(a.prev=a.next){case 0:return n=e.url,o=e.data,r=e.headers,t.loading=!0,a.prev=2,a.next=5,t.$axios.get(n,o,{headers:r});case 5:s=a.sent,t.roles=s.data,a.next=12;break;case 9:a.prev=9,a.t0=a["catch"](2),console.log(a.t0);case 12:t.loading=!1;case 13:case"end":return a.stop()}}),a,null,[[2,9]])})))()},submit:function(){},reset:function(){this.form=Object(s["a"])({},this.user)}}},c=i,d=a("2877"),u=a("6544"),m=a.n(u),f=a("8336"),v=a("62ad"),p=a("a523"),b=a("0fd9"),g=a("b974"),h=a("8654"),x=Object(d["a"])(c,n,o,!1,null,null,null);t["default"]=x.exports;m()(x,{VBtn:f["a"],VCol:v["a"],VContainer:p["a"],VRow:b["a"],VSelect:g["a"],VTextField:h["a"]})}}]);
//# sourceMappingURL=settings.6faea073.js.map