<template>
  <v-container pa-0 ma-0>
    <v-hover v-slot:default="{ hover }">
      <v-subheader class="mt-4 grey--name name--darken-1">
        <v-container grid-list-md>
          <v-layout align-center>
            <v-flex shrink>
              <span>{{$t('app.navigation-panel.areas.subscribes.title')}}</span>
            </v-flex>
            <v-flex mx-1 v-if="hover">
              <v-tooltip top color="red">
                <template v-slot:activator="{ on }">
                  <v-icon  @click="goToSubscribes()" v-on="on">
                    fa-eye
                  </v-icon>
                </template>
                  {{ $t('Детальнее') }}
              </v-tooltip>
            </v-flex>
          </v-layout>
        </v-container>
      </v-subheader>
    </v-hover>

      <v-list>
        <v-tooltip color="red" top v-for="(subscribe, index) in subscribes" :key="index">
          <template v-slot:activator="{ on }">
            <v-list-item @click="" v-on="on">
              <v-list-item-avatar>
                <img :src="`https://randomuser.me/api/portraits/men/${subscribe.picture}.jpg`" />
              </v-list-item-avatar>
              <v-list-item-title v-text="subscribe.name"></v-list-item-title>
            </v-list-item>
          </template>
          <v-layout>
            <v-flex>
              <span>{{ $t('Дней осталось: ') }}</span>
            </v-flex>
            <v-flex>
              <span>{{ subscribe.daysLeft }}</span>
            </v-flex>
          </v-layout>
        </v-tooltip>
      </v-list>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({})
export default class Subscribes extends Vue {
  subscribes: any[] = [
    { picture: 28, name: 'Kaper1', daysLeft: 10 },
    { picture: 38, name: 'Kaper2', daysLeft: 15 },
    { picture: 48, name: 'Kaper3', daysLeft: 2 },
    { picture: 58, name: 'Kaper4', daysLeft: 31 },
    { picture: 78, name: 'Kaper5', daysLeft: 7 },
  ];

  goToSubscribes() {
    this.$router.push('/subscribes');
  }
}
</script>
