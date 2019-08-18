<template>
  <v-app id="inspire" dark>

    <router-view v-if="isNotFoundPage"></router-view>
    <div v-else>
      <app-navigation-drawer :drawer="drawer"/>
      <app-toolbar :drawer.sync="drawer"/>

      <v-content>
        <v-container fill-height>
            <router-view></router-view>
        </v-container>
      </v-content>

      <app-footer/>
    </div>
  </v-app>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import AppToolbar from './toolbar/app-toolbar.vue';
import AppNavigationDrawer from './navigation_drawer/app-navigation-drawer.vue';
import AppFooter from './footer/app-footer.vue';
import { notFoundPageName } from './constants';

@Component({
  components: {
    AppToolbar, 
    AppNavigationDrawer, 
    AppFooter
  }
})
export default class DefaultLayout extends Vue {
  public drawer: boolean = true;

  get currentRoute() {
    return this.$route.name;
  }

  get isNotFoundPage() {
    return this.currentRoute === notFoundPageName;
  }
}

</script>
