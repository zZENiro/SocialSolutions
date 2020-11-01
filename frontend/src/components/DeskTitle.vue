<template>
  <div class="desk-title" :class="$vuetify.theme.dark ? 'border-bottom border-primary' : 'grey lighten-3'">
    <v-container :class="$vuetify.theme.dark ? 'secondary--text text--darken-4' : 'secondary--text'">
      <div class="text-h4 text-sm-h3 my-6 my-sm-12">
        <slot name="title">
          <template>{{ title }}</template>
        </slot>
      </div>
      <div class="text-h5 my-3" v-html="subtitle"></div>
    </v-container>
  </div>
</template>
<script>
export default {
  props: {
    title: String,
    subtitle: String,
  },
}
</script>
<style lang="scss">
  .border-bottom {
    border-bottom: 1px solid;
  }
  .border-primary {
    border-color: var(--v-primary-base);
  }
  .desk-title {
    background-image: url('~@/assets/img/bg2.svg');
    background-repeat: no-repeat;
    background-size: cover;
    background-position: top right;
  }
</style>
