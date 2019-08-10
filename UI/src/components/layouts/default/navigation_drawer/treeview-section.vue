<template>
  <v-container pa-0 ma-0>
    <v-list nav
            dense>
      <v-list-item-group v-model="itemSelected" color="gray">
        <router-link tag="div" v-for="(item, index) in navigationItems" :key="index"  :to="item.path">
          <v-list-item>
            <v-list-item-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title>{{ $t(item.localeKey) }}</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </router-link>
      </v-list-item-group>
    </v-list>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Watch } from "vue-property-decorator";

@Component({})
export default class Treeview extends Vue {
  itemSelected: number | null = null;
  navigationItems: any[] = [
    { icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.home', path: '/' },
    { icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.available-subscribes', path: '/kapers' },
    { icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.sales', path: '/sales' },
    //{ icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.black-list', path: '/blackList' },
    { icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.contacts', path: '/contacts' },
    //{ icon: 'featured_play_list', localeKey: 'app.navigation-panel.areas.pages.report-kaper', path: '/reportKaper' },
  ];

  mounted() {
    
  }

  get currentRoute() {
    return this.$route.path;
  }

  get currentRouteItemIndex() {
    return this.navigationItems.indexOf(this.currentRouteItem);
  }

  get currentRouteItem() {
    const item = this.navigationItems.find( i => i.path === this.currentRoute);

    return item || this.navigationItems.find(i => i.path === '/');
  }

  @Watch('currentRouteItemIndex')
  onRouteIndexChanged(value: number) {
    this.itemSelected = value;
  }
}
</script>
