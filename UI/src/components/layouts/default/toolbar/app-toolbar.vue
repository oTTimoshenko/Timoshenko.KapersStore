<template>
  <v-app-bar ref="app-bar"
             app 
             clipped-left 
						 color="red" 
						 dense>
    <v-app-bar-nav-icon @click.stop="internalDrawer = !internalDrawer"></v-app-bar-nav-icon>

    <v-toolbar-title class="mr-12 align-center">
      <router-link to="/" tag="div">
        <div class="home-title">
          <span class="title">{{$t('app.toolbar.title')}}</span>
        </div>
      </router-link>
    </v-toolbar-title>

    <v-spacer></v-spacer>
    <v-layout justify-end align-center>
      <v-flex shrink>
        <change-language>

        </change-language>
      </v-flex>
      <v-flex shrink mx-5>
        <cart-avatar></cart-avatar>
      </v-flex>
      <v-flex shrink>
        <user-avatar v-if="isUserAuthenticated"></user-avatar>
        <login-popup v-else></login-popup>
      </v-flex>
    </v-layout>
  </v-app-bar>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

import ChangeLanguage from '@/components/layouts/default/locale/change-language.vue';
import UserAvatar from './user/avatar/UserAvatar.vue';
import CartAvatar from '@/components/layouts/default/cart/avatar/CartAvatar.vue';
import LoginPopup from '@/components/layouts/default/toolbar/user/login-registration/LoginPopUp.vue';

@Component({
  components: {
    ChangeLanguage,
    UserAvatar,
    CartAvatar,
    LoginPopup
  }
})
export default class AppToolbar extends Vue {
  @Prop({default: true}) drawer!: boolean;
  
  public internalDrawer = true;

  public get isUserAuthenticated() {
    if(this.$store && this.$store.getters)
      return this.$store.getters.isAuthenticated;

    return false;
  }

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

<style lang="scss" scoped>
.home-title:hover {
  cursor: pointer;
  color: rgb(212, 212, 212);
}
</style>
