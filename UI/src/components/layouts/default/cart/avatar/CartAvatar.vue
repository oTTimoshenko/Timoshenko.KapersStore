<template>
    <v-badge
      bottom
      color="blue">
      <template v-slot:badge>
        <span>{{cartSubscribesCount}}</span>
      </template>
      <v-btn small icon @click="goToCart()">
        <v-icon size="30">fa-shopping-cart</v-icon>
      </v-btn>
    </v-badge>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class CartAvatar extends Vue {
  cartSubscribesCount: number = 3;

  goToCart() {
    this.$router.push('/cart');
  }
}

</script>

<style lang="scss" scoped>

</style>
