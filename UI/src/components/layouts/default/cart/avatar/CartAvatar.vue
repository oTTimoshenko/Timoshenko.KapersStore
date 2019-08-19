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

import { CartKaper } from '@/components/layouts/default/cart/types';
import cartService from './../cartService';
import EventBus from '@/plugins/eventBus'

@Component({})
export default class CartAvatar extends Vue {
  cartSubscribesCount: number = 0;

  created() {
    EventBus.$off(['cart:changed', 'cart:item-added']);
    EventBus.$on('cart:changed', this.reloadSubscribesCount);
    EventBus.$on('cart:item-added', this.addItem);
  }

  mounted() {
    this.reloadSubscribesCount();
  }

  addItem(kaper: CartKaper) {
    cartService.addItem(kaper);
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
