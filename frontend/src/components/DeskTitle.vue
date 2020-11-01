<template>
  <div
    class="desk-title"
    :class="{
      'border-bottom border-primary': $vuetify.theme.dark,
      'grey lighten-3': !$vuetify.theme.dark,
      [`desk-title-${image}`]: true,
    }"
  >
    <v-container :class="$vuetify.theme.dark ? '' : 'secondary--text'">
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
    image: {
      type: Number,
      default: 1,
    },
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
    background-repeat: no-repeat;
    background-size: cover;
    background-position: top right;
  }
  @each $num in (1, 2, 3) {
    .desk-title-#{$num} {
      background-image: url('~@/assets/img/bg'+$num+'.svg');
    }
  }
</style>
