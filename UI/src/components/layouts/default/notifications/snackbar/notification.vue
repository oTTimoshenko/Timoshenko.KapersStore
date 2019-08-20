<template>
  <v-snackbar
    :timeout="15000"
    v-model="snackbarModel">
    {{ message }}

    <v-btn
      color="red"
      text
      @click="continueSubscription">
      {{$t('Continue')}}
    </v-btn>
    <v-btn
      color="red"
      text
      @click="snackbarModel = false">
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
  message: string = 'Your subscription for Kaper1:Subscription1 is ending, do u want to continue it?';

  continueSubscription() {
    this.$router.push('/kapers');
    this.snackbarModel = false;
  }
}

</script>

<style lang="scss" scoped>

</style>
