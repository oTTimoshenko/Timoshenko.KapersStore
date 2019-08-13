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
                <span class="title">{{item.kaperName}}</span>
              </v-flex>
              <v-flex mx-1 v-if="hover">
                <v-btn small icon>
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
                          <v-btn x-small icon>
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

@Component({})
export default class CartItem extends Vue {
  @Prop() item!: any;

  minusCount(subscription: any) {
    subscription.count = subscription.count > 1 ? subscription.count - 1 : 1;
  }

  plusCount(subscription: any) {
    subscription.count++;
  }
}

</script>

<style lang="scss" scoped>

</style>
