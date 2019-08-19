<template>
  <v-container>
    <v-list dense>
      <v-list-item v-for="(item, index) in items" :key="index">
        <cart-item :item="item"/>
      </v-list-item>
    </v-list>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import CartItem from './cart-item.vue'

import { CartKaper } from './types';
import EventBus from '@/plugins/eventBus'

@Component({
  components: {
    CartItem
  }
})
export default class CartItemsList extends Vue {
  @Prop() items!: CartKaper[];

  mounted() {
    EventBus.$on('cart:remove-kaper', this.removeKaper);
    EventBus.$on('cart:remove-subscription', (id: number) => this.removeSubscription(id));
  }

  removeKaper(id: number) {
    EventBus.$emit('cart:remove-kaper', id);
  }

  removeSubscription(id: number) {
    debugger
    EventBus.$emit('cart:remove-subscription', id);
  }
}

</script>

<style lang="scss" scoped>

</style>
