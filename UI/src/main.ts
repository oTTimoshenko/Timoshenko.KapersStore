import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import Vuetify from 'vuetify'
import VueRouter from 'vue-router'
import i18n from './i18n'
import Vuelidate from 'vuelidate'

Vue.config.productionTip = false

Vue.use(VueRouter);
Vue.use(Vuetify);
Vue.use(Vuelidate);


new Vue({
  router,
  vuetify,
  components: { App },
  template: '<App />',
  store,
  i18n,
  render: h => h(App)
}).$mount('#app')
