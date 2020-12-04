<template>
  <v-bottom-navigation app color="primary">
    <v-btn v-for="(item, i) in menu" :key="i" :to="item.href">
      <span>{{item.title}}</span>

      <v-icon>{{item.icon}}</v-icon>
    </v-btn>
  </v-bottom-navigation>
</template>
<script>
export default {
  props: {
    menu: Array,
  },
}
</script>
