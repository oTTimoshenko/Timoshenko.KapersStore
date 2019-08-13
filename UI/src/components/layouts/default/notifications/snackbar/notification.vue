<template>
  <v-snackbar
    timeout="15000"
    v-model="snackbarModel">
    {{ message }}

    <v-btn
      color="red"
      text
      @click="continueSubscribe">
      {{$t('Continue')}}
    </v-btn>
    <v-btn
      color="red"
      text
      @click="snackbar = false">
      {{$t('Close')}}
    </v-btn>
  </v-snackbar>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class CartAvatar extends Vue {
  snackbarModel: boolean = true;
  message: string = 'Your subscription for Kaper1:Subscribe1 is ending, do u want to continue it?';

  continueSubscribe() {
    this.$router.push('/kapers');
  }
}

</script>

<style lang="scss" scoped>

</style>
