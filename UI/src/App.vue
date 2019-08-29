<template>
  <div id="app">
    <DefaultLayout/>
  </div>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { DefaultLayout } from '@/components/layouts/default/index'
import axios from 'axios';
import { notFoundPageName } from '@/components/layouts/default/constants'

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
}

</script>

<style lang="scss">
.content-text {
  word-break: break-word;
}
</style>
