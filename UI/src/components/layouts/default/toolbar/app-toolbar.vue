<template>
  <v-app-bar app 
             clipped-left 
						 color="red" 
						 dense>
    <v-app-bar-nav-icon @click.stop="internalDrawer = !internalDrawer"></v-app-bar-nav-icon>

    <v-icon class="mx-4">featured_play_list</v-icon>

    <v-toolbar-title class="mr-12 align-center">
      <span class="title">{{$t('app.toolbar.title')}}</span>
    </v-toolbar-title>

    <v-spacer></v-spacer>

    <v-layout align-center style="max-width: 650px">
      <v-text-field :append-icon-cb="() => {}"
        						placeholder="Search..."
        						single-line
        						append-icon="search"
        						color="white"
        						hide-details>
			</v-text-field>
    </v-layout>
  </v-app-bar>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

@Component({})
export default class AppToolbar extends Vue {
  @Prop({default: true}) drawer!: boolean;
  
  public internalDrawer = true;

  @Watch('drawer')
  onDrawerChanged(value: boolean) {
    this.internalDrawer = value;
  }

  @Watch('internalDrawer')
  onInternalDrawerChanged(value: boolean) {
    this.$emit('update:drawer', value);
  }

}
</script>
