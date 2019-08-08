<template>
  <v-container pa-0 ma-0>

    <v-list-item class="mt-4" @click="">
      <v-list-item-action>
        <v-icon color="grey darken-1">add_circle_outline</v-icon>
      </v-list-item-action>
      <v-list-item-title class="grey--text text--darken-1">Buy subscription</v-list-item-title>
    </v-list-item>

    <v-list-item @click="">
      <v-list-item-action>
        <v-icon color="grey darken-1">settings</v-icon>
      </v-list-item-action>
      <v-list-item-title class="grey--text text--darken-1">Account Settings</v-list-item-title>
    </v-list-item>

  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component } from "vue-property-decorator";

@Component({})
export default class Settings extends Vue {

}
</script>
