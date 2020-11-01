<template>
  <v-list nav>
    <v-list-item class="px-2">
      <v-list-item-avatar>
        <v-img src="https://cdn.vuetifyjs.com/images/john.png"></v-img>
      </v-list-item-avatar>
      <v-list-item-title>{{ user && user.name }} {{ user && user.secondName }}</v-list-item-title>
      <v-btn
        icon
        @click.stop="$emit('update:drawer-mini', !drawerMini)"
      >
        <v-icon>mdi-chevron-left</v-icon>
      </v-btn>
    </v-list-item>
    <v-list-item two-line>
      <v-list-item-content v-if="!drawerMini">
        <v-list-item-title>{{ user && user.mobilePhone }}</v-list-item-title>
        <v-list-item-subtitle>{{ role && role.name || 'Роль не выбрана' }}</v-list-item-subtitle>
      </v-list-item-content>
      <v-list-item-action>
        <v-btn icon to="/profile/settings" active-class="primary--text">
          <v-icon>mdi-cog</v-icon>
        </v-btn>
      </v-list-item-action>
    </v-list-item>
  </v-list>
</template>
<script>
import { mapState } from 'vuex';

export default {
  props: {
    drawerMini: Boolean,
  },
  computed: {
    ...mapState(['user', 'role']),
  },
}
</script>
