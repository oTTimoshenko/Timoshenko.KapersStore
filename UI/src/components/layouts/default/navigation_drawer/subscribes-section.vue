<template>
  <v-container pa-0 ma-0>
      <v-subheader class="mt-4 grey--text text--darken-1">{{$t('app.navigation-panel.areas.subscribes.title')}}</v-subheader>

      <v-list>
        <v-list-item v-for="item in items" :key="item.text" @click="">
          <v-list-item-avatar>
            <img :src="`https://randomuser.me/api/portraits/men/${item.picture}.jpg`" alt />
          </v-list-item-avatar>
          <v-list-item-title v-text="item.text"></v-list-item-title>
        </v-list-item>
      </v-list>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({})
export default class Subscribes extends Vue {
  items: any[] = [
    { picture: 28, text: 'Kaper1' },
    { picture: 38, text: 'Kaper2' },
    { picture: 48, text: 'Kaper3' },
    { picture: 58, text: 'Kaper4' },
    { picture: 78, text: 'Kaper5' },
  ];
}
</script>
