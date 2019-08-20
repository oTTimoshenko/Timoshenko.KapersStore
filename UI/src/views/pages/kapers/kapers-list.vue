<template>
  <v-expansion-panels multiple popout>
    <v-expansion-panel
      v-for="(kaper, index) in Kapers"
      :key="index">
      <v-expansion-panel-header>
        <v-layout align-center>
          <v-flex md1>
            <v-avatar size="46px">
              <img :src="kaper.imageSource"
                   :alt="kaper.altText">
            </v-avatar>
          </v-flex>
          <v-flex shrink>
            <span class="subtitle-1">{{ kaper.name }}</span>
          </v-flex>
        </v-layout>
      </v-expansion-panel-header>
      <v-expansion-panel-content pa-0>
        <v-card flat>
          <v-layout column>
            <v-flex>
              <span>{{ kaper.description }}</span>
            </v-flex>
            <v-flex>
              <v-btn color="red" small @click="goToDetails(kaper.id)">
                {{$t('Details page')}}
                <v-icon  right small>
                  fa-arrow-right
                </v-icon>
              </v-btn>
            </v-flex>
            <v-flex>
              <v-layout>
                <v-flex>
                  <kaper-subscribes-list :subscriptions="kaper.subscriptions"></kaper-subscribes-list>
                </v-flex>
              </v-layout>
            </v-flex>
          </v-layout>
        
        </v-card>
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

import KaperSubscribesList from './kaper-subscribes-list.vue'

import { CartKaper, CartSubscription, CartState } from '@/components/layouts/default/cart/types';
import EventBus from '@/plugins/eventBus'

@Component({
  components: {
    KaperSubscribesList
  }
})
export default class KapersList extends Vue {
  @Prop({default: []}) kapers!: any[];

  get Kapers() {
    return this.kapers && this.kapers.length > 0 ? this.kapers : [];
  }

  goToDetails(kaperId: number) {
    this.$router.push({name: 'kaperDetails', params: { kaperId: kaperId.toString() }})
  }

  created() {
    EventBus.$off('kaper-subscriptions:add-to-cart');
    EventBus.$on('kaper-subscriptions:add-to-cart', this.addKaperToCart);
  }

  addKaperToCart(subscriptionId: number) {
    const kaper = this.kapers.find(k => k.subscriptions
                                    .find(s => s.id === subscriptionId));

    const cartKaper = new CartKaper(kaper.id, kaper.name, kaper.subscriptions.filter(s => s.id === subscriptionId).map(s => new CartSubscription(s.id, s.name, s.price)));

    EventBus.$emit('cart:item-added', cartKaper);
  }
}
</script>

<style lang="scss" scoped>
.kaper-buy-button {
  width: 10%;
}

.app-link {
  cursor: pointer;
  color: #F44336;
}
</style>
