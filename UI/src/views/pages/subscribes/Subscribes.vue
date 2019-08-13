<template>
  <v-container fill-height>
    <v-layout column>
      <subscribes-group :subscribes="activeSubscribes" :title="$t('Активные')" color=""/>

      <subscribes-group :subscribes="closedSubscribes" :title="$t('Истекшие')" color=""/>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'
import SubscribesGroup from './subscribes-group.vue'

@Component({
  components: {
    SubscribesGroup
  }
})
export default class Subscribes extends Vue {
  subscribes: any[] = [
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'ACTIVE' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' },
    { icon: 'fa-telegram', kapperName: 'Kaper1', name: 'Subscribe1', startDate: '09/10/19', endDate: '27/10/19', price: '2000 руб.', status: 'CLOSED' }
  ];

  get activeSubscribes() {
    return this.subscribes.filter(s => s.status === 'ACTIVE');
  }

  get closedSubscribes() {
    return this.subscribes.filter(s => s.status === 'CLOSED');
  }
}
</script>