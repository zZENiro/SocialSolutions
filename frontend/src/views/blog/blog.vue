<template>
  <router-view></router-view>
</template>
<script>
export default {
  data() {
    return {
      submenu: [
        {
          title: 'Проблемы и решения',
          href: '/blog/solutions',
          icon: 'mdi-gift',
        },
        {
          title: 'Истории',
          href: '/blog/stories',
          icon: 'mdi-information-variant',
        },
        {
          title: 'Новости',
          href: '/blog/news',
          icon: 'mdi-gift',
        },
        {
          title: 'Предложения',
          href: '/blog/offers',
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
