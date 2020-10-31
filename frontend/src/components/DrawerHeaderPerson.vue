<template>
  <v-list nav>
    <v-list-item class="px-2">
      <v-list-item-avatar>
        <v-img src="https://cdn.vuetifyjs.com/images/john.png"></v-img>
      </v-list-item-avatar>
      <v-list-item-title>John Leider</v-list-item-title>
      <v-btn
        icon
        @click.stop="$emit('update:drawer-mini', !drawerMini)"
      >
        <v-icon>mdi-chevron-left</v-icon>
      </v-btn>
    </v-list-item>
    <v-list-item two-line>
      <v-list-item-content v-if="!drawerMini">
        <v-list-item-title>Two-line item</v-list-item-title>
        <v-list-item-subtitle>Secondary text</v-list-item-subtitle>
      </v-list-item-content>
      <v-list-item-action>
        <v-btn icon to="/profile/settings" active-class="primary--text">
          <v-icon>mdi-settings</v-icon>
        </v-btn>
      </v-list-item-action>
    </v-list-item>
  </v-list>
</template>
<script>
export default {
  props: {
    drawerMini: Boolean,
  },
}
</script>
