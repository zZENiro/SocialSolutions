<template>
  <router-view></router-view>
</template>
<script>
export default {
  data() {
    return {
      submenu: [
        {
          title: 'Финансово',
          href: '/donut/charity',
          icon: 'mdi-gift',
        },
        {
          title: 'Информационно',
          href: '/donut/info',
          icon: 'mdi-information-variant',
        },
        {
          title: 'Делом',
          href: '/donut/deal',
          icon: 'mdi-account-group',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
