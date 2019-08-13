<template>
  <v-layout justify-center>
    <v-dialog v-model="dialog" max-width="600px">
      <template v-slot:activator="{ on }">
        <v-btn color="primary" dark v-on="on">Open Dialog</v-btn>
      </template>
      <registration-form></registration-form>
    </v-dialog>
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
}
</script>

<style lang="scss" scoped>

</style>
