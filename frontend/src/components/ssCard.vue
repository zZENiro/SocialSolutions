<template>
  <router-link class="ss-card" :to="item.href || '#'">
    <div class="ss-card-image" :style="`background-image: url('${item.image}');`">
      <v-icon v-if="empty">mdi-plus</v-icon>
    </div>
    <div class="ss-card-title" :class="{'ss-card-title-empty': empty}">{{ item.title || 'Добавить' }}</div>
  </router-link>
</template>
<script>
export default {
  props: {
    item: Object,
    empty: Boolean,
  },
}
</script>
<style lang="scss">
  .ss-card {
    display: flex;
    min-width: 275px;
    width: 100%;
    flex-direction: column;
    border: 1px solid black;
    border-radius: 2rem;
    background-color: white;
    text-decoration: none;
    color: inherit!important;
    transition: all .2s ease;
    box-shadow: 0 0 1.5rem rgba($primary, .25);
  }
  .ss-card:hover {
    box-shadow: 0 0 1.5rem rgba($primary, .5);
  }
  .ss-card-image {
    display: flex;
    align-items: center;
    justify-content: center;
    border-radius: inherit;
    width: inherit;
    height: 190px;
    background-repeat: no-repeat;
    background-position: center;
    background-size: cover;

    .v-icon {
      font-size: 8rem;
      color: rgba(black, .3);
    }
  }
  .ss-card-title-empty {
    color: rgba(black, .3)!important;
  }
  .ss-card-title {
    padding: 1rem 1.5rem;
  }
</style>
