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
          icon: 'mdi-sync-alert',
        },
        {
          title: 'Истории',
          href: '/blog/stories',
          icon: 'mdi-bookshelf',
        },
        {
          title: 'Новости',
          href: '/blog/news',
          icon: 'mdi-newspaper-variant-outline',
        },
        {
          title: 'Предложения',
          href: '/blog/offers',
          icon: 'mdi-head-lightbulb-outline',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
