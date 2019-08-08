<template>
  <v-card-text>TEST</v-card-text>
</template>

<script>

import Vue from 'vue';
import { Watch, Component } from 'vue-property-decorator';

@Component({})

export default class  {
  created () {
    this.$vuetify.theme.dark = true
  }
}
</script>


