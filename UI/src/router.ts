import Vue from 'vue'
import VueRouter from 'vue-router'

export default new VueRouter({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: () => import('./views/pages/home/Home.vue')
    },
    {
      path: '/kapers',
      name: 'kapers',
      component: () => import('./views/pages/kapers/Kapers.vue')
    },
    {
      path: '/kapers/:kaperId/details',
      name: 'kaperDetails',
      component: () => import('./views/pages/kapers/details/KaperDetails.vue')
    },
    {
      path: '/blackList',
      name: 'blackList',
      component: () => import('./views/pages/blackList/BlackList.vue')
    },
    {
      path: '/contacts',
      name: 'contacts',
      component: () => import('./views/pages/contacts/Contacts.vue')
    },
    {
      path: '/reportKaper',
      name: 'reportKaper',
      component: () => import('./views/pages/reportKaper/ReportKaper.vue')
    },
    {
      path: '/sales',
      name: 'sales',
      component: () => import('./views/pages/sales/Sales.vue')
    },
    {
      path: '/subscribes',
      name: 'subscribes',
      component: () => import('./views/pages/subscribes/Subscribes.vue')
    },
    {
      path: '/registration',
      name: 'registration',
      component: () => import('./components/layouts/default/toolbar/user/login-registration/Registration.vue')
    },
    {
      path: '/login',
      name: 'login',
      component: () => import('./components/layouts/default/toolbar/user/login-registration/Login.vue')
    },
    {
      path: '/cart',
      name: 'cart',
      component: () => import('./components/layouts/default/cart/Cart.vue')
    }
  ]
})
