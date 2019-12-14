<template>
  <v-container pr-0>
    <v-menu v-model="dialog" offset-y nudge-bottom="7vh" min-width="35vw" attach :close-on-content-click="false" offset-overflow left>
      <template v-slot:activator="{ on }">
        <v-btn color="white" class="login-button" v-on="on">{{$t('Login')}}</v-btn>
      </template>
      <v-card>
        <login-form v-on:closeDialog="closeDialog()"></login-form>
      </v-card>
    </v-menu>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import LoginForm from './login-form.vue';
import EventBus from '@/plugins/eventBus.ts';

@Component({
  components: {
    LoginForm
  }
})
export default class LoginPopUp extends Vue {
  dialog: any = false;

  closeDialog() {
    this.dialog = false;
  }

  mounted() {
    EventBus.$on('login-pop-up:close', () => this.dialog = false);
  }
}
</script>

<style lang="scss" scoped>
.login-button {
  color: #F44336 !important;
}
</style>
