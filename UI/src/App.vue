<template>
  <div id="app">
    <DefaultLayout/>
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

<style lang="scss">
.content-text {
  word-break: break-word;
}
</style>
