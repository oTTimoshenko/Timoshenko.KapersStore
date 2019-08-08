<template>
  <div id="app">
    <default-layout/>
  </div>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { DefaultLayout } from '@/components/layouts/default/index'

@Component({
  components: {
    DefaultLayout
  }
})
export default class App extends Vue {

}

</script>
