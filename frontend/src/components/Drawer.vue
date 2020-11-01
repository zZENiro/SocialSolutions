<template>
  <v-navigation-drawer
    :value="drawer"
    @input="(val) => $emit('update:drawer', val)"
    :mini-variant="drawerMini"
    @update:mini-variant="(val) => $emit('update:drawerMini', val)"
    clipped
    app
    touchless
    :width="$vuetify.breakpoint.smAndUp ? 300 : 256"
    :mini-variant-width="4 * 16"
  >
    <DrawerHeaderPerson
      v-if="$route.matched.some((el) => el.path === '/profile')"
      :drawerMini="drawerMini"
      @update:drawer-mini="(val) => $emit('update:drawer-mini', val)"
      class="mb-n3"
    />
    <v-list nav>
      <v-list-item
        v-for="(item, i) in submenu"
        :key="i"
        :to="item.href"
        exact
        class="px-2"
        active-class="primary--text"
      >
        <v-list-item-action>
          <v-icon>{{ item.icon }}</v-icon>
        </v-list-item-action>
        <v-list-item-content>
          <v-list-item-title>{{ item.title }}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
    <DrawerMapFilters v-if="$route.path === '/community/business'" />
  </v-navigation-drawer>
</template>
<script>
import { mapState } from 'vuex'
import DrawerHeaderPerson from '@/components/DrawerHeaderPerson.vue';
import DrawerMapFilters from '@/components/DrawerMapFilters.vue';

export default {
  props: {
    drawer: Boolean,
    drawerMini: Boolean,
  },
  components: {
    DrawerHeaderPerson,
    DrawerMapFilters,
  },
  data() {
    return {
      menu: [
        // {
        //   title: 'Business',
        //   href: '/business',
        //   icon: 'mdi-hand',
        // },
      ],
    }
  },
  computed: {
    ...mapState({
      submenu(state) {
        return [...state.submenu, ...this.menu];
      },
    }),
  },
}
</script>
<style lang="scss">
</style>
