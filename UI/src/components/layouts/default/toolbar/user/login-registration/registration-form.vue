<template>
  <v-container ma-0 pa-0>
      <v-card-title v-if="!registratedSuccessfully">
        {{$t('Registration')}}
      </v-card-title>
  
      <v-card-text>
        <v-container grid-list-md>
          <v-layout column v-if="!registratedSuccessfully">
            <v-text-field required v-model="email" :label="$t('Email')" :error-messages="emailErrors" @input="$v.email.$touch()" @blur="$v.email.$touch()">
            
            </v-text-field>
            <v-text-field required v-model="nickname" :label="$t('Nickname')" :error-messages="nicknameErrors" @input="$v.nickname.$touch()" @blur="$v.nickname.$touch()">
            
            </v-text-field>
            <v-text-field required v-model="password" :label="$t('Password')" :error-messages="passwordErrors" @input="$v.password.$touch()" @blur="$v.password.$touch()">
            
            </v-text-field>
            <v-text-field required v-model="confirmPassword" :label="$t('Confirm Password')" :error-messages="confirmPasswordErrors" @input="$v.confirmPassword.$touch()" @blur="$v.confirmPassword.$touch()">
            
            </v-text-field>

            <v-card-text v-if="isResponseMessageAvailable">
              {{responseMessage}}
            </v-card-text>
          </v-layout>
          <v-layout align-center column v-else>
            <v-flex shrink>
              <v-icon x-large>fa-telegram</v-icon>
            </v-flex>
            <v-flex grow>
              <v-card-text class="headline text-md-center">
                {{$t('Ur account registrated successully, check ur email to confirm the account')}}
              </v-card-text>
            </v-flex>
          </v-layout>
        </v-container>
      </v-card-text>
  
      <v-card-actions v-if="!registratedSuccessfully">
        <v-spacer></v-spacer>
        <v-layout justify-end ma-1>
          <v-btn @click="closeDialog()">
            {{$t('Cancel')}}
          </v-btn>
          <v-btn @click="submit" color="red" :loading="isLoading">
            {{$t('Registrate')}}
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
    email: { required, email },
    nickname: { required, minLength: minLength(6), maxLength: maxLength(20) },
    password: { required, minLength: minLength(6), maxLength: maxLength(18) },
    confirmPassword: { sameAsPassword: sameAs('password') }
  }
})
export default class RegistrationForm extends Vue {
  email: string = '';
  nickname: string = '';
  password: string = '';
  confirmPassword: string = '';

  responseMessage: string | null = null;
  registratedSuccessfully: boolean = false;
  isLoading: boolean = false;

  get isResponseMessageAvailable() {
    return !isNull(this.responseMessage);
  }

  get emailErrors() {
    const errors = [] as any;

    if(isNullOrUndefined(this.$v.email) || !this.$v.email.$dirty) return errors;

    !(this.$v.email as any).email && errors.push(this.$t('Email is invalid'))
    !(this.$v.email as any).required && errors.push(this.$t('Email is required'))

    return errors;
  }

  get nicknameErrors() {
    const errors = [] as any;

    if(isNullOrUndefined(this.$v.nickname) || !this.$v.nickname.$dirty) return errors;

    !(this.$v.nickname as any).minLength && errors.push(this.$t('Nickname has to be more than 6 characters'))
    !(this.$v.nickname as any).maxLength && errors.push(this.$t('Nickname has to be less than 20 characters'))
    !(this.$v.nickname as any).required && errors.push(this.$t('Nickname is required'))

    return errors;
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

  get registrationModel() {
    return {
      nickname: this.nickname,
      email: this.email,
      password: this.password
    }
  }

  closeDialog() {
    this.$emit('closeDialog');
  }

  submit() {
    this.$v.$touch();

    if(!this.$v.$invalid) {
      this.isLoading = true;
      apiService.post('users', 'registrate', this.registrationModel)
                  .catch(error => console.log(error))
                  .then(response => this.registratedSuccessfully = true)
                  .finally(() => this.isLoading = false);
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
