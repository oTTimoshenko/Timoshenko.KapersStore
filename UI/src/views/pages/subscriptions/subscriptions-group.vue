<template>
  <v-container>
    <v-card flat :color="color">
      <v-card-title>
        <span>{{title}}</span>
      </v-card-title>
      <v-card-text>
        <v-card v-for="(subscription, index) in subscriptions" :key="index" tile>
          <v-layout align-center>
            <v-flex shrink>
              <v-card-text>
                <v-icon large>{{subscription.icon}}</v-icon>
              </v-card-text>
            </v-flex>
            <v-card-text>
              <v-layout align-center>
                <v-flex grow>
                  <v-layout column>
                    <v-flex mb-3>
                      <v-layout align-end justify-start>
                        <v-flex shrink>
                          <span class="title">{{subscription.kapperName}} </span>
                        </v-flex>
                        <v-flex mx-2>
                          <span class="subtitle-1">{{subscription.name}}</span>
                        </v-flex>
                      </v-layout>
                    </v-flex>
                    <v-flex>
                      <v-layout>
                        <v-flex mr-12 shrink>
                          <span>{{$t('Куплено: ')}}{{subscription.startDate}}</span>
                        </v-flex>
                        <v-flex>
                          <span>{{$t('Закончится: ')}}{{subscription.endDate}}</span>
                        </v-flex>
                      </v-layout>
                    </v-flex>
                  </v-layout>
                </v-flex>
                <v-flex mx-6 shrink>
                  <v-layout column>
                    <v-flex class="text-center">
                      <span class="subtitle-1">{{$t('Дней осталось: ')}}</span>
                    </v-flex>
                    <v-flex class="text-center">
                      <span class="title">{{getDaysLeft(subscription.startDate, subscription.endDate)}}</span>
                    </v-flex>
                  </v-layout>
                </v-flex>
                <v-flex mx-6 shrink>
                  <span class="subtitle-1">{{subscription.price}}</span>
                </v-flex>
              </v-layout>
            </v-card-text>
          </v-layout>
        </v-card>
      </v-card-text>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

@Component({})
export default class SubscriptionsGroup extends Vue {
  @Prop() subscriptions!: any[];
  @Prop({default: 'Подписки'}) title!: string;
  @Prop() color!: string;

  getDaysLeft(startDate, endDate) {
    return '20';
  }
}
</script>

<style lang="scss" scoped>
.subscription-item {
  background-color: rgb(255,255,255, 0.2);
}
</style>