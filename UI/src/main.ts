import Vue from 'vue'
import App from './App.vue'
import router from './router'
import store from './store'
import vuetify from './plugins/vuetify'
import Vuetify from 'vuetify'
import VueRouter from 'vue-router'
import axios from 'axios'
import i18n from './i18n'
import Vuelidate from 'vuelidate'
import apiService from '@/components/layouts/default/helpers/services/apiService';
import constants from '@/components/layouts/default/helpers/constants/constants'

Vue.config.productionTip = false
Vue.prototype.$http = axios;
Vue.prototype.apiService = apiService;

const token = localStorage.getItem(constants.userToken);
debugger
if(token) axios.defaults.headers.common[constants.authorizationHeaderName] = token;

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
