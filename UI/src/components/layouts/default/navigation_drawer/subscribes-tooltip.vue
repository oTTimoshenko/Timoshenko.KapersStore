<template>
  <v-container pa-0 ma-0>
    
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({})
export default class SubscribesTooltip extends Vue {
  items: any[] = [
    { picture: 28, text: 'Kaper1' },
    { picture: 38, text: 'Kaper2' },
    { picture: 48, text: 'Kaper3' },
    { picture: 58, text: 'Kaper4' },
    { picture: 78, text: 'Kaper5' },
  ];
}
</script>
