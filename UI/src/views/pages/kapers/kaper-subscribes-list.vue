<template>
  <v-list>
    <v-list-item
      v-for="(subscription, index) in subscriptions"
      :key="index">
      <v-layout column>

      
        <v-layout align-center>
          <v-flex>
            <span class="subtitle-1">{{ subscription.name }}</span>
          </v-flex>
          <v-flex shrink mx-7>
            <span class="subtitle-1">{{ $t(subscription.price + ' руб.') }}</span>
          </v-flex>
          <v-flex shrink>
            <v-btn @click="addSubscriptionToCart(subscription.id)" class="kaper-buy-button" color="red">
              {{$t('Buy')}}
              <v-icon right>fa-shopping-cart</v-icon>
            </v-btn>
          </v-flex>
        </v-layout>
        <v-divider></v-divider>
      </v-layout>
    </v-list-item>
  </v-list>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

import EventBus from '@/plugins/eventBus'

@Component({})
export default class KapersList extends Vue {
  @Prop({default: []}) subscriptions!: any[];

  addSubscriptionToCart(id: number) {
    EventBus.$emit('kaper-subscriptions:add-to-cart', id);
  }
}
</script>

<style lang="scss" scoped>

</style>
