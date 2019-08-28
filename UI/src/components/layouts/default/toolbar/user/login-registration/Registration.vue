<template>
  <v-layout justify-center>
    <v-flex md6>
      <registration-form v-on:closeDialog="closeDialog()"></registration-form>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import RegistrationForm from './registration-form.vue';

@Component({
  components: {
    RegistrationForm
  }
})
export default class Registration extends Vue {
  dialog: any = true;

  closeDialog() {
    this.dialog = false;
  }
}
</script>

<style lang="scss" scoped>

</style>
