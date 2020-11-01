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
          icon: 'mdi-briefcase',
        },
        {
          title: 'Люди',
          href: '/community/people',
          icon: 'mdi-account',
        },
        {
          title: 'Сообщества',
          href: '/community/groups',
          icon: 'mdi-account-group',
        },
        {
          title: 'Мероприятия',
          href: '/community/events',
          icon: 'mdi-calendar-check',
        },
        {
          title: 'Карта доступности',
          href: '/community/business',
          icon: 'mdi-map-marker',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
