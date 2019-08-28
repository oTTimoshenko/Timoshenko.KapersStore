<template>
  <v-menu offset-y>
    <template v-slot:activator="{ on }">
      <v-avatar v-on="on">
        <v-btn icon>
          <v-icon x-large>fa-telegram</v-icon>
        </v-btn>
      </v-avatar>
    </template>
    <v-list>
      <v-list-item @click="goToRoute('/subscriptions')">
        <v-list-item-icon>
          <v-icon>
            fa-telegram
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>{{$t('My subscriptions')}}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>

      <v-list-item @click="logout()">
        <v-list-item-icon>
          <v-icon>
            fa-telegram
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title>{{$t('Logout')}}</v-list-item-title>
        </v-list-item-content>
      </v-list-item>
    </v-list>
  </v-menu>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

@Component({})
export default class UserAvatar extends Vue {
  goToRoute(route: string) {
    this.$router.push(route);
  }

  logout() {
    this.$store.dispatch('AUTH_LOGOUT').then(() => this.$router.push({name: 'home'}));
  }
}
</script>

<style lang="scss" scoped>
  
</style>
