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

import cartService from './../cartService';
import EventBus from '@/plugins/eventBus'

@Component({})
export default class CartAvatar extends Vue {
  cartSubscribesCount: number = 3;

  created() {
    EventBus.$on('cart:changed', this.reloadSubscribesCount);
  }

  mounted() {
    this.reloadSubscribesCount();
  }

  reloadSubscribesCount() {
    const cart = cartService.state;
    this.cartSubscribesCount = cart ? cart.subscriptionsCount : 0;
  }

  goToCart() {
    this.$router.push('/cart');
  }
}

</script>

<style lang="scss" scoped>

</style>
