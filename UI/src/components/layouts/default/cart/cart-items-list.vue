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

@Component({
  components: {
    CartItem
  }
})
export default class CartItemsList extends Vue {
  @Prop() items!: CartKaper[];
}

</script>

<style lang="scss" scoped>

</style>
