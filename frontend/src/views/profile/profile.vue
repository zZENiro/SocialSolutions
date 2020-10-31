<template>
  <router-view></router-view>
</template>
<script>
export default {
  data() {
    return {
      submenu: [
        {
          title: 'Профиль',
          href: '/profile',
          icon: 'mdi-gift',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
