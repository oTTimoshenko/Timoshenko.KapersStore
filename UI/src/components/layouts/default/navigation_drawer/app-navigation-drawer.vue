<template>
  <v-navigation-drawer v-model="drawer" app clipped>
    <v-list dense>

      <treeview-section/>

      <subscriptions-section/>

      <settings-section v-if="withSettings"/>

    </v-list>
  </v-navigation-drawer>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import TreeviewSection from './treeview-section.vue';
import SubscriptionsSection from './subscriptions-section.vue';
import SettingsSection from './settings-section.vue';

@Component({
  components: {
    TreeviewSection, SubscriptionsSection, SettingsSection
  }
})
export default class AppNavigationDrawer extends Vue {
  @Prop({default: true}) drawer!: boolean;
  @Prop({ default: false}) withSettings!: boolean;
}
</script>
