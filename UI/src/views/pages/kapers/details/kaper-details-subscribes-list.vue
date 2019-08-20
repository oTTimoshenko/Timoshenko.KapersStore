<template>
  <v-expansion-panels multiple popout>
    <v-expansion-panel
      v-for="(subscription, index) in subscriptions"
      :key="index">
      <v-expansion-panel-header>
        <v-layout align-center>
          <v-flex shrink>
            <span class="subtitle-1">{{`${subscription.name} (${subscription.totalDays} days)`}}</span>
          </v-flex>
          <v-flex>
            <span class="subtitle-1">{{ $t(subscription.price + ' руб.') }}</span>
          </v-flex>
        </v-layout>
      </v-expansion-panel-header>
      <v-expansion-panel-content pa-0>
        <v-card flat>
          {{ subscription.description }}
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn @click="addSubscriptionToCart(subscription.id)" class="kaper-buy-button" color="red">
              {{$t('Buy')}}
              <v-icon right>fa-shopping-cart</v-icon>
            </v-btn>
          </v-card-actions>
        </v-card>
        
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

import EventBus from '@/plugins/eventBus'

@Component({})
export default class KapersList extends Vue {
  @Prop({type: [], default: []}) subscriptions!: any[];

  addSubscriptionToCart(id: number) {
    EventBus.$emit('kaper-subscriptions:add-to-cart', id);
  }
}
</script>

<style lang="scss" scoped>

</style>
