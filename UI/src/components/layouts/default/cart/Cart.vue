<template>
  <v-container>
    <v-card>
      <v-card-title>
        {{$t('Cart')}}
      </v-card-title>
      <v-divider></v-divider>
      <v-card-text v-if="cart.subscriptionsCount <= 0" class="cart-items-container text-md-center">
        <span class="display-1">{{$t('Your cart is empty')}}</span> 
      </v-card-text>
      <v-card-text  v-else class="cart-items-container">
        <cart-items-list :items="cart.items"></cart-items-list>
        <v-layout mb-5 align-center justify-end>
          <v-flex shrink>
            <span class="headline">{{$t('Total price: ')}}</span>
          </v-flex>
          <v-flex mx-5 shrink>
            <span class="headline">{{$t(cart.totalPrice + ' руб.')}}</span>
          </v-flex>
        </v-layout>
      </v-card-text>
      <v-divider></v-divider>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-layout align-end justify-end>
          <v-flex shrink mx-3>
            <router-link tag="span" to="/kapers">
              <span class="text-router-link">{{$t('Продолжить покупки...')}}</span>
            </router-link>
          </v-flex>
          <v-flex md4 ma-1 v-if="cart.subscriptionsCount > 0">
            <v-btn color="red" block large>
              <span class="title">{{$t('BUY')}}</span> 
              <v-icon size="25" right>fa-shopping-cart</v-icon>
            </v-btn>
          </v-flex>
        </v-layout>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop, Watch } from 'vue-property-decorator';

import CartItemsList from './cart-items-list.vue';

import cartService from './cartService';
import { CartKaper, CartSubscription, CartState } from './types';
import EventBus from '@/plugins/eventBus'

@Component({
  components: {
    CartItemsList
  }
})
export default class Cart extends Vue {
  cart: CartState = new CartState([]);  

  mounted() {
    this.reloadCart();
  }

  reloadCart() {
    if(cartService.state) this.cart = cartService.state as CartState; 
  }

  created() {
    EventBus.$off(['cart:remove-kaper', 'cart:remove-subscription']);
    EventBus.$on('cart:remove-kaper', this.removeKaper);
    EventBus.$on('cart:remove-subscription', this.removeSubscription);
  }

  removeKaper(id: number) {
    cartService.removeKaper(this.cart, id);
  }

  removeSubscription(id: number) {
    cartService.removeSubscription(this.cart, id);
  }

  @Watch('cart', { deep: true })
  onCartChanged(newValue: CartState) {
    cartService.setState(newValue);
  }
}

</script>

<style lang="scss" scoped>
.text-router-link:hover {
  cursor: pointer;
}

.text-router-link {
  color: #F44336;
}

.cart-items-container {
  min-height: 25vh
}
</style>
