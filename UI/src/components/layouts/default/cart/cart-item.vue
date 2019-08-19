<template>
  <v-layout column my-5>
    <v-flex>
      <v-hover v-slot:default="{ hover }">
        <v-layout align-center>
          <v-flex shrink>
            <v-icon x-large>fa-telegram</v-icon>
          </v-flex>
          <v-flex mx-12>
            <v-layout align-center>
              <v-flex shrink>
                <span class="title">{{item.name}}</span>
              </v-flex>
              <v-flex mx-1 v-if="hover">
                <v-btn @click="removeKaper()" small icon>
                  <v-icon>fa-times</v-icon>
                </v-btn>
              </v-flex>
            </v-layout>
          </v-flex>
          <v-flex shrink>
            <span class="title">{{$t(item.totalPrice + ' руб.')}}</span>
          </v-flex>
        </v-layout>
      </v-hover>
    </v-flex>
    <v-flex>
      <v-layout align-center>
        <v-flex md6 offset-md1>
          <v-layout column>
              <v-flex v-for="(subscription, index) in item.subscriptions" :key="index" offset-md-1>
                <v-hover v-slot:default="{ hover }">
                  <v-layout align-center>
                    <v-flex grow>
                      <v-layout align-center>
                        <v-flex shrink>
                          <span class="subtitle-1">{{subscription.name}}</span>
                        </v-flex>
                        <v-flex mx-1 v-if="hover">
                          <v-btn @click="removeSubscription(subscription.id)" x-small icon>
                            <v-icon>fa-times</v-icon>
                          </v-btn>
                        </v-flex>
                      </v-layout>
                    </v-flex>
                    <v-flex mx-3 shrink>
                      <v-layout align-center>
                        <v-btn small icon @click="minusCount(subscription)">
                          <v-icon>fa-minus</v-icon>
                        </v-btn>
                        <v-flex mx-2 shrink>
                          <span class="subtitle-1">{{subscription.count}}</span>
                        </v-flex>
                        <v-btn small icon @click="plusCount(subscription)">
                          <v-icon>fa-plus</v-icon>
                        </v-btn>
                      </v-layout>
                    </v-flex>
                    <v-flex shrink>
                      <span class="subtitle-1">{{$t(subscription.totalPrice + ' руб.')}}</span>
                    </v-flex>
                  </v-layout>
                </v-hover>
              </v-flex>
          </v-layout>
        </v-flex>
      </v-layout>
    </v-flex>
    <v-divider></v-divider>
  </v-layout>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import { CartKaper, CartSubscription, CartState } from './types';

import cartService from './cartService';
import EventBus from '@/plugins/eventBus'

@Component({})
export default class CartItem extends Vue {
  @Prop() item!: CartKaper;

  minusCount(subscription: CartSubscription) {
    subscription.minusCount();
  }

  plusCount(subscription: any) {
    subscription.plusCount();
  }

  removeKaper() {
    EventBus.$emit('cart:remove-kaper', this.item.id);
  }

  removeSubscription(id: number) {
    EventBus.$emit('cart:remove-subscription', id);
  }
}

</script>

<style lang="scss" scoped>

</style>
