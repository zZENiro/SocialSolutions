import Vue from 'vue'
import VueRouter from 'vue-router'
import Home from '../views/Home.vue'

Vue.use(VueRouter)

const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home
  },
  {
    path: '/login',
    name: 'login',
    component: () => import(/* webpackChunkName: "Login" */ '@/views/Login.vue')
  },
  {
    path: '/blog',
    name: 'blog',
    component: () => import(/* webpackChunkName: "blog" */ '@/views/blog/blog.vue'),
    children: [
      {
        path: '',
        name: 'blog-index',
        component: () => import(/* webpackChunkName: "blog-index" */ '@/views/blog/index.vue'),
      },
      {
        path: 'solutions',
        name: 'solutions',
        component: () => import(/* webpackChunkName: "solutions" */ '@/views/blog/solutions.vue'),
      },
      {
        path: 'offers',
        name: 'offers',
        component: () => import(/* webpackChunkName: "offers" */ '@/views/blog/offers.vue'),
      },
      {
        path: 'news',
        name: 'news',
        component: () => import(/* webpackChunkName: "news" */ '@/views/blog/news.vue'),
      },
      {
        path: 'stories',
        name: 'stories',
        component: () => import(/* webpackChunkName: "stories" */ '@/views/blog/stories.vue'),
      },
    ],
  },
  {
    path: '/community',
    name: 'community',
    component: () => import(/* webpackChunkName: "community" */ '@/views/community/community.vue'),
    children: [
      {
        path: '',
        name: 'community-index',
        component: () => import(/* webpackChunkName: "community-index" */ '@/views/community/index.vue'),
      },
      {
        path: 'groups',
        name: 'groups',
        component: () => import(/* webpackChunkName: "groups" */ '@/views/community/groups.vue'),
      },
      {
        path: 'events',
        name: 'events',
        component: () => import(/* webpackChunkName: "events" */ '@/views/community/events.vue'),
      },
      {
        path: 'work',
        name: 'work',
        component: () => import(/* webpackChunkName: "work" */ '@/views/community/work.vue'),
      }
      ,{
        path: 'business',
        name: 'business',
        component: () => import(/* webpackChunkName: "business" */ '@/views/community/Business.vue'),
      },
    ],
  },
  {
    path: '/donut',
    name: 'donut',
    component: () => import(/* webpackChunkName: "donut" */ '@/views/donut/donut.vue'),
    children: [
      {
        path: '',
        name: 'donut-index',
        component: () => import(/* webpackChunkName: "donut-index" */ '@/views/donut/index.vue'),
      },
      {
        path: 'charity',
        name: 'charity',
        component: () => import(/* webpackChunkName: "charity" */ '@/views/donut/charity.vue'),
      },
      {
        path: 'info',
        name: 'info',
        component: () => import(/* webpackChunkName: "info" */ '@/views/donut/info.vue'),
      },
      {
        path: 'deal',
        name: 'deal',
        component: () => import(/* webpackChunkName: "deal" */ '@/views/donut/deal.vue'),
      }
    ],
  },
  {
    path: '/profile',
    name: 'profile',
    component: () => import(/* webpackChunkName: "profile" */ '@/views/profile/profile.vue'),
    children: [
      {
        path: '',
        name: 'profile-index',
        component: () => import(/* webpackChunkName: "profile-index" */ '@/views/profile/index.vue'),
      },
      {
        path: 'settings',
        name: 'settings',
        component: () => import(/* webpackChunkName: "settings" */ '@/views/profile/settings.vue'),
      },
    ]
  },
]

const router = new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes
})

export default router
