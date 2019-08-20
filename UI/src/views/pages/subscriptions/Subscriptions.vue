<template>
  <v-container fill-height>
    <v-layout column>
      <subscriptions-group :subscriptions="activeSubscriptions" :title="$t('Активные')" color=""/>

      <subscriptions-group :subscriptions="closedSubscriptions" :title="$t('Истекшие')" color=""/>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'
import SubscriptionsGroup from './subscriptions-group.vue'

@Component({
  components: {
    SubscriptionsGroup
  }
})
export default class Subscriptions extends Vue {
  subscriptions: any[] = [
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscription1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' }
  ];

  get activeSubscriptions() {
    return this.subscriptions.filter(s => s.status === 'ACTIVE');
  }

  get closedSubscriptions() {
    return this.subscriptions.filter(s => s.status === 'CLOSED');
  }
}
</script>