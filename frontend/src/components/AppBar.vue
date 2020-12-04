<template>
  <v-app-bar
    app
    :color="$vuetify.theme.dark ? 'dark' : 'white'"
    clipped-left
    class="elevation-primary"
  >
    <v-app-bar-nav-icon @click="$emit('update:drawer', !drawer)"></v-app-bar-nav-icon>
    <router-link to="/">
      <img v-if="!$vuetify.theme.dark" height="44" src="@/assets/img/logo2.svg" alt="">
      <img v-else height="44" src="@/assets/img/logo2-dark.svg" alt="">
    </router-link>
    <transition name="slide-top" mode="out-in" tag="div" :css="true" class="col">
      <v-text-field
        outlined
        flat
        color="primary"
        rounded
        :hide-details="true"
        label="Поиск"
        dense
        :height="44"
        class="ml-3"
        v-if="openSearch"
        key="1"
        v-click-outside="() => { if (openSearch) openSearch = !openSearch; }"
      ></v-text-field>
      <div v-else class="d-flex col" key="2">
        <div class="d-none d-sm-flex justify-center col">
          <v-btn
            v-for="(item, i) in menu" :key="i"
            :to="item.href"
            :title="item.tile"
            rounded
            :text="$route.path !== item.href"
            large
            :color="$route.path === item.href ? 'primary' : ''"
            depressed
            class="ml-3"
          >
            {{ item.title }}
          </v-btn>
        </div>
        <v-spacer class="d-flex d-sm-none"></v-spacer>
        <div class="ml-3 d-flex align-center" v-if="!token || !user">
          <v-btn
            to="/login"
            class="d-none d-sm-flex"
            rounded
            depressed
            large
            title="Вход"
            :text="$route.path !== '/login'"
            :color="$route.path === '/login' ? 'primary' : ''"
          >
            Вход
          </v-btn>
          <v-btn
            to="/login"
            color="primary"
            class="d-flex d-sm-none"
            icon
            title="Вход"
          >
            <v-icon>mdi-login</v-icon>
          </v-btn>
        </div>
        <div v-if="token && user" class="d-flex ml-3 align-center">
          <v-btn
            pill
            class="d-none d-sm-flex pr-2"
            depressed
            outlined
            large
            rounded
            title="Сообщения"
          >
            <v-icon>mdi-email</v-icon>
            <v-chip color="error" class="ml-3">2</v-chip>
          </v-btn>
          <v-menu
            open-on-hover
            offset-y
            rounded="xl"
          >
            <template v-slot:activator="{ on, attrs }">
              <v-btn
                class="d-none d-sm-flex pr-0 ml-3"
                depressed
                large
                rounded
                color="primary"
                title="Профиль"
                to="/profile"
                v-bind="attrs"
                v-on="on"
              >
                <span>{{ user && user.name }}</span>
                <v-avatar right :size="44" class="ml-3">
                  <v-img src="https://cdn.vuetifyjs.com/images/john.png"></v-img>
                </v-avatar>
              </v-btn>
            </template>
            <v-list class="py-0">
              <v-list-item @click="logout">
                <v-list-item-title>Выход</v-list-item-title>
              </v-list-item>
            </v-list>
          </v-menu>
          <v-btn
            class="d-flex d-sm-none"
            rounded
            icon
            large
            color="primary"
            @click="logout"
            title="Выход"
          >
            <v-icon>mdi-logout</v-icon>
          </v-btn>
        </div>
        <div class="d-flex ml-3 align-center">
          <v-btn
            class="d-none d-sm-flex"
            rounded
            depressed
            large
            :outlined="!badEye"
            :color="badEye ? 'primary' : ''"
            @click="$store.dispatch('setBadEye', !badEye)"
            title="Версия для слабовидящих"
          >
            <v-icon>mdi-eye</v-icon>
          </v-btn>
          <v-btn
            @click="$store.dispatch('setBadEye', !badEye)"
            color="primary"
            class="d-flex d-sm-none"
            icon
          >
            <v-icon>mdi-eye</v-icon>
          </v-btn>
        </div>
      </div>
    </transition>
    <v-btn
      icon
      @click="openSearch = !openSearch"
      class="mr-0"
      :outlined="$vuetify.breakpoint.mdAndUp"
      color="primary"
    >
      <v-icon >mdi-magnify</v-icon>
    </v-btn>
  </v-app-bar>
</template>
<script>
import { mapState } from 'vuex';

export default {
  props: {
    drawer: Boolean,
    drawerMini: Boolean,
    menu: Array,
  },
  data() {
    return {
      openSearch: false,
    }
  },
  computed: {
    ...mapState(['token', 'user', 'badEye']),
  },
  methods: {
    logout() {
      this.$store.dispatch('logout');
    },
  },
}
</script>
