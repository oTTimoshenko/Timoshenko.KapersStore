<template>
  <v-layout justify-center>
    <v-dialog v-model="dialog" max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="primary" dark v-on="on">Open Dialog</v-btn>
      </template>
      <login-form v-on:closeDialog="closeDialog()"></login-form>
    </v-dialog>
  </v-layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import LoginForm from './login-form.vue';

@Component({
  components: {
    LoginForm
  }
})
export default class Login extends Vue {
  dialog: any = true;

  closeDialog() {
    this.dialog = false;
  }
}
</script>

<style lang="scss" scoped>

</style>
