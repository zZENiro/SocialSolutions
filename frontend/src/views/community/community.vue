<template>
  <router-view></router-view>
</template>
<script>
export default {
  data() {
    return {
      submenu: [
        {
          title: 'Поиск работы',
          href: '/community/work',
          icon: 'mdi-gift',
        },
        {
          title: 'Группы',
          href: '/community/groups',
          icon: 'mdi-gift',
        },
        {
          title: 'Мероприятия',
          href: '/community/events',
          icon: 'mdi-information-variant',
        },
        {
          title: 'Карта доступности',
          href: '/community/business',
          icon: 'mdi-hand',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
