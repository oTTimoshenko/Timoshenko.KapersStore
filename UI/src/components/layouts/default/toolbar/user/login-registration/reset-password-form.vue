<template>
  <v-container ma-0 pa-0>
      <v-card-title>
        {{$t('Reset Password')}}
      </v-card-title>
  
      <v-card-text>
        <v-container grid-list-md>
          <v-layout column>
            <v-text-field required v-model="password" :label="$t('New Password')" :error-messages="passwordErrors" @input="$v.password.$touch()" @blur="$v.password.$touch()">
            </v-text-field>

            <v-text-field required v-model="confirmPassword" :label="$t('Confirm New Password')" :error-messages="confirmPasswordErrors" @input="$v.confirmPassword.$touch()" @blur="$v.confirmPassword.$touch()">
            </v-text-field>

            <v-card-text v-if="isResponseMessageAvailable">
              {{responseMessage}}
            </v-card-text>
          </v-layout>
        </v-container>
      </v-card-text>
  
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-layout justify-end ma-1>
          <v-btn @click="submit" color="red" :loading="isLoading">
            {{$t('Submit')}}
          </v-btn>
        </v-layout>
      </v-card-actions>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

import { validationMixin } from 'vuelidate';
import { required, maxLength, minLength, email, sameAs } from 'vuelidate/lib/validators'
import { isNullOrUndefined, isNull } from 'util';
import apiService from '@/components/layouts/default/helpers/services/apiService'

@Component({
  mixins: [validationMixin],
  validations: {
    password: { required, minLength: minLength(6), maxLength: maxLength(18) },
    confirmPassword: { sameAsPassword: sameAs('password') }
  }
})
export default class ResetPasswordForm extends Vue {
  @Prop({default: false}) resettedSuccessfully!: boolean;
  @Prop({default: false}) isInError!: boolean;
  password: string = '';
  confirmPassword: string = '';

  responseMessage: string | null = null;
  isLoading: boolean = false;

  get isResponseMessageAvailable(): boolean {
    return !isNull(this.responseMessage);
  }

  get email(): string {
    return this.$route.params.email;
  }

  get code(): string {
    return this.$route.params.code;
  }

  get passwordErrors() {
    const errors = [] as any;

    if(isNullOrUndefined(this.$v.password) || !this.$v.password.$dirty) return errors;

    !(this.$v.password as any).minLength && errors.push(this.$t('Password has to be more than 6 characters'))
    !(this.$v.password as any).maxLength && errors.push(this.$t('Password has to be less than 18 characters'))
    !(this.$v.password as any).required && errors.push(this.$t('Password is required'))

    return errors;
  }

  get confirmPasswordErrors() {
    const errors = [] as any;

    if(isNullOrUndefined(this.$v.confirmPassword) || !this.$v.confirmPassword.$dirty) return errors;

    !(this.$v.confirmPassword as any).sameAsPassword && errors.push(this.$t('Password must by identical'))

    return errors;
  }

  get resetPasswordModel() {
    return {
      email: this.email,
      code: this.code,
      newPassword: this.password
    }
  }

  submit() {
    this.$v.$touch();

    if(!this.$v.$invalid) {
      this.isLoading = true;
      apiService.post('users', 'resetPassword', this.resetPasswordModel)
                  .catch(error => { console.log(error); this.$emit('update:isInError', true);})
                  .then(response => { this.$emit('update:resettedSuccessfully', true); this.$emit('update:isInError', false);})
                  .finally(() => this.isLoading = false);
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
