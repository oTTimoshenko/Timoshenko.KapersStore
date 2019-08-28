<template>
  <v-layout justify-center>
    <v-flex md6>
      <login-form v-on:closeDialog="closeDialog()"></login-form>
    </v-flex>
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

}
</script>

<style lang="scss" scoped>

</style>
