<template>
  <v-container>
    <v-card>
      <v-card-title>
        {{$t('Cart')}}
      </v-card-title>
      <v-divider></v-divider>
      <v-card-text>
        <cart-items-list :items="items"></cart-items-list>
        <v-layout mb-5 align-center justify-end>
          <v-flex shrink>
            <span class="headline">{{$t('Total price: ')}}</span>
          </v-flex>
          <v-flex mx-5 shrink>
            <span class="headline">{{$t(totalPrice + ' руб.')}}</span>
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
          <v-flex md4 ma-1>
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
import { Component, Prop } from 'vue-property-decorator';

import CartItemsList from './cart-items-list.vue';

@Component({
  components: {
    CartItemsList
  }
})
export default class Cart extends Vue {
  items: any[] = [
    { kaperName: 'Kaper1', totalPrice: 123, subscriptions: [
                                              { name: 'Subscription1', count: 1, totalPrice: 130, price: 110 },
                                              { name: 'Subscription2', count: 2, totalPrice: 230, price: 210 },
                                              { name: 'Subscription3', count: 3, totalPrice: 330, price: 1120 },
                                            ] },
    { kaperName: 'Kaper2', totalPrice: 234, subscriptions: [
                                              { name: 'Subscription4', count: 4, totalPrice: 430, price: 1140 }
                                            ] },
    // { kaperName: 'Kaper3', totalPrice: 345, subscriptions: [
    //                                           { name: 'Subscription5', count: 2, totalPrice: 430, price: 1105 },
    //                                           { name: 'Subscription6', count: 3, totalPrice: 350, price: 1101 },
    //                                           { name: 'Subscription7s', count: 4, totalPrice: 230, price: 1130 },
    //                                         ] }
  ];
  totalPrice: number = 1234;
}

</script>

<style lang="scss" scoped>
.text-router-link:hover {
  cursor: pointer;
}

.text-router-link {
  color: #F44336;
}
</style>
