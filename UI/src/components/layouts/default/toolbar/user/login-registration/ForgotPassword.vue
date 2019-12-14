<template>
  <v-layout justify-center v-if="!isSuccessfull">
    <v-flex md6>
      <forgot-password-form :isSuccessfull.sync="isSuccessfull"></forgot-password-form>
    </v-flex>
  </v-layout>
  <v-layout align-center column v-else>
    <v-flex shrink>
      <v-icon x-large>fa-telegram</v-icon>
    </v-flex>
    <v-flex grow>
      <v-card-text class="headline text-md-center">
        {{$t('Ur password successfully resetted! Check ur email to change ur password!')}}
      </v-card-text>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import ForgotPasswordForm from './forgot-password-form.vue';

@Component({
  components: {
    ForgotPasswordForm
  }
})
export default class ForgotPassword extends Vue {
  isSuccessfull: boolean = false;
}
</script>

<style lang="scss" scoped>

</style>
