<template>
  <v-container ma-0 pa-0>
      <v-card-title>
        {{$t('Password Reset')}}
      </v-card-title>
  
      <v-card-text>
        <v-container grid-list-md>
          <v-layout column>
            <v-flex>
              <span>{{$t('Put here ur email pleeeeeeeeease')}}</span>
            </v-flex>
            <v-flex>
              <v-text-field v-model="email"
                            @input="$v.email.$touch()"
                            @blur="$v.email.$touch()"
                            :label="$t('Email')"
                            :error-messages="emailErrors"
                            required>
              </v-text-field>
            </v-flex>
          </v-layout>
        </v-container>
      </v-card-text>
  
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-layout justify-end ma-1>
          <v-btn :loading="isSending" @click="submit" color="red">
            {{$t('Send')}}
          </v-btn>
        </v-layout>
      </v-card-actions>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch, Mixins } from "vue-property-decorator";

import { validationMixin } from 'vuelidate';
import { required, maxLength, minLength, email } from 'vuelidate/lib/validators'
import { isNullOrUndefined } from 'util';
import EventBus from '@/plugins/eventBus.ts';
import apiService from '../../../helpers/services/apiService';

@Component({
  mixins: [validationMixin],
  validations: {
    email: {  required, email }
  }
})
export default class ForgotPasswordForm extends Vue {
  @Prop({default: false}) isSuccessfull!: boolean;

  email: string = '';
  isSending: boolean = false;

  get emailErrors(): any[] {
    const errors = [] as any;
    if(isNullOrUndefined (this.$v.email) || !this.$v.email.$dirty) return errors;

    !(this.$v.email as any).email && errors.push(this.$t('E-mail must be valid'))
    !(this.$v.email as any).required && errors.push(this.$t('E-mail is required'))

    return errors;
  } 

  submit() {
    this.$v.$touch();

    if(!this.$v.$invalid) {
      this.isSending = true;
      apiService.post('users', 'resetPassword/request', { email: this.email })
        .then(response => this.$emit('update:isSuccessfull', true))
        .finally(() => this.isSending = false);
    }
  }

}
</script>

<style lang="scss" scoped>
.link-text:hover {
  cursor: pointer;
}
</style>
