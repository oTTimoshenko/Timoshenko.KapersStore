<template>
  <div id="app">
    <DefaultLayout/>
  </div>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Watch } from 'vue-property-decorator';
import { DefaultLayout } from '@/components/layouts/default/index'
import axios from 'axios';
import { notFoundPageName } from '@/components/layouts/default/constants'
import constants from './components/layouts/default/helpers/constants/constants';

@Component({
  components: {
    DefaultLayout
  }
})
export default class App extends Vue {
 created() {

   axios.interceptors.response.use(undefined, error => {
     return new Promise((resolve, reject) => {
       if(error.status === 401 && error.config && !error.config.__isRetryRequest) {
         this.$store.dispatch('AUTH_LOGOUT')
       }

       if(error.status === 404)
        this.$router.push({name: notFoundPageName});

       throw error;
     })
   })
 }

 @Watch('$i18n.locale', { deep: true })
 private onLocaleChanged(newValue: string) {
   axios.defaults.headers.common[constants.locale] = newValue.toUpperCase();
 }
}

</script>

<style lang="scss">
.content-text {
  word-break: break-word;
}
</style>
