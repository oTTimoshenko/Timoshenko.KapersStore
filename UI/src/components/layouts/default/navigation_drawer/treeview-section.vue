<template>
  <v-container pa-0 ma-0>
    <v-list-item v-for="item in items" :key="item.text" @click="">
      <v-list-item-action>
        <v-icon>{{ item.icon }}</v-icon>
      </v-list-item-action>
      <v-list-item-content>
        <v-list-item-title>{{ item.text }}</v-list-item-title>
      </v-list-item-content>
    </v-list-item>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({})
export default class Treeview extends Vue {
  items: any[] = [
    { icon: 'featured_play_list', text: 'Page1' },
    { icon: 'featured_play_list', text: 'Page2' },
    { icon: 'featured_play_list', text: 'Page3' },
    { icon: 'featured_play_list', text: 'Page4' },
    { icon: 'featured_play_list', text: 'Page5' },
  ];
}
</script>
