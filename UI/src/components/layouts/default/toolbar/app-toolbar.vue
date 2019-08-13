<template>
  <v-app-bar app 
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
      <v-flex shrink>
        <user-avatar></user-avatar>
      </v-flex>
    </v-layout>
  </v-app-bar>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import ChangeLanguage from './change-language.vue';
import UserAvatar from './user/avatar/UserAvatar.vue';

@Component({
  components: {
    ChangeLanguage,
    UserAvatar
  }
})
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

<style lang="scss" scoped>
.home-title:hover {
  cursor: pointer;
  color: rgb(212, 212, 212);
}
</style>
