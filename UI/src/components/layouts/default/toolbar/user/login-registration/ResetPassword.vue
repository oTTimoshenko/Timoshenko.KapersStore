<template>
  <v-container fill-height>
    <v-layout align-center v-if="!resettedSuccessfully && isInError">
      <v-flex grow>
        <v-card-text class="headline text-md-center">
          {{$t('Something went wrong')}}
        </v-card-text>
      </v-flex>
    </v-layout>
    <v-layout align-center justify-center v-else-if="!resettedSuccessfully && !isInError">
      <v-flex md6>
        <reset-password-form :resettedSuccessfully.sync="resettedSuccessfully" :isInError.sync="isInError"></reset-password-form>
      </v-flex>
    </v-layout>
    <v-layout align-center column v-else-if="resettedSuccessfully && !isInError">
      <v-flex shrink>
        <v-icon x-large>fa-telegram</v-icon>
      </v-flex>
      <v-flex grow>
        <v-card-text class="headline text-md-center">
          {{$t('Ur password successfully resetted! Let`s log in with new password!')}}
        </v-card-text>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import LoginForm from './login-form.vue';
import apiService from '../../../helpers/services/apiService';
import Loading from '@/components/layouts/default/loading/loading.vue';
import ResetPasswordForm from './reset-password-form.vue';

@Component({
  components: {
    LoginForm,
    Loading,
    ResetPasswordForm
  }
})
export default class ResetPassword extends Vue {
  resettedSuccessfully: boolean = false;
  isInError: boolean = false;

  // get email() {
  //   return this.$route.params.email;
  // }

  // get code() {
  //   return this.$route.params.code;
  // }

  // created() {
  //   apiService.post('users', 'confirmEmail', { email: this.email, code: this.code  })
  //               .catch(error => this.$router.push({name: 'home'}))
  //               .then(response => this.isConfirmed = true);
  // }
}
</script>

<style lang="scss" scoped>

</style>
