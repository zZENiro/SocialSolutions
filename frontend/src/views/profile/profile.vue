<template>
  <router-view></router-view>
</template>
<script>
export default {
  data() {
    return {
      submenu: [
        {
          title: 'Панель управления',
          href: '/profile',
          icon: 'mdi-account-cog',
        },
        {
          title: 'Мои льготы',
          href: '/profile/documents',
          icon: 'mdi-text-box-check-outline',
        },
      ],
    }
  },
  mounted() {
    this.$store.commit('SET_SUBMENU', this.submenu);
  },
}
</script>
