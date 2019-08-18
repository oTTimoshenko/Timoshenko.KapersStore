<template>
  <div id="app">
    <v-app id="inspire" dark>
      <v-content>
        <v-img width="100%" max-height="100vh"  src="http://getwallpapers.com/wallpaper/full/8/c/c/29000.jpg">
          <v-container pa-12 fill-height>
            <v-layout column align-center justify-center>
              <v-flex shrink>
                  <span class="large-text-xl font-weight-regular">{{$t('404')}}</span>
              </v-flex>
              <v-flex shrink>
                  <span class="display-1">{{$t('Page not found')}}</span>
              </v-flex>
              <v-flex shrink>
                <v-layout justify-center>
                  <v-flex md8>
                    <v-card-text class="text-md-center">
                      <span class="subheading">{{$t('Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim.')}}</span>
                    </v-card-text>
                  </v-flex>
                </v-layout>
              </v-flex>
              <v-flex shrink>
                <v-card-text>
                  <v-btn @click="goToHomePage" color="red">
                    {{$t('Go home')}}
                  </v-btn>
                </v-card-text>
              </v-flex>
            </v-layout>
          </v-container>
        </v-img>
      </v-content>
    </v-app>
  </div>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class NotFound extends Vue {

  goToHomePage() {
    this.$router.push('/');
  }
}

</script>

<style lang="scss" scoped>
.large-text-xl {
  font-size: 140px !important;
}
</style>
