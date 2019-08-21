<template>
  <v-container ma-0 pa-0>
    <v-card>
      <v-card-title>
        {{$t('Login')}}
      </v-card-title>
  
      <v-card-text>
        <v-container grid-list-md>
          <v-layout column>
            <v-text-field v-model="email"
                          @input="$v.email.$touch()"
                          @blur="$v.email.$touch()"
                          :label="$t('Email')"
                          :error-messages="emailErrors"
                          required>
            </v-text-field>

            <v-text-field v-model="password"
                          @input="$v.password.$touch()"
                          @blur="$v.password.$touch()"
                          :label="$t('Password')"
                          :error-messages="passwordErrors"
                          required>
            </v-text-field>
          </v-layout>
        </v-container>
      </v-card-text>
  
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-layout justify-end ma-1>
          <v-btn @click="closeDialog()">
            {{$t('Cancel')}}
          </v-btn>
          <v-btn @click="submit" color="red">
            {{$t('Login')}}
          </v-btn>
        </v-layout>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch, Mixins } from "vue-property-decorator";

import { validationMixin } from 'vuelidate';
import { required, maxLength, minLength, email } from 'vuelidate/lib/validators'
import { isNullOrUndefined } from 'util';

@Component({
  mixins: [validationMixin],
  validations: {
    email: {  required, email },
    password: { required, minLength: minLength(6), maxLength: maxLength(18) }
  }
})
export default class LoginForm extends Vue {
  email: string = '';
  password: string = '';

  get emailErrors(): any[] {
    const errors = [] as any;
    if(isNullOrUndefined (this.$v.email) || !this.$v.email.$dirty) return errors;

    !(this.$v.email as any).email && errors.push(this.$t('E-mail must be valid'))
    !(this.$v.email as any).required && errors.push(this.$t('E-mail is required'))

    return errors;
  } 

  get passwordErrors() {
    const errors = [] as any;
    if(isNullOrUndefined (this.$v.password) || !this.$v.password.$dirty) return errors;

    !(this.$v.password as any).minLength && errors.push(this.$t('Password can not be less than 6 characters'));
    !(this.$v.password as any).maxLength && errors.push(this.$t('Password can not be more that 18 characters'));
    !(this.$v.password as any).required && errors.push(this.$t('Password is required'));

    return errors;
  }

  closeDialog() {
    this.$emit('closeDialog');
  }

  submit() {
    this.$v.$touch();

    if(this.$v.$invalid) {
      alert('Errors!')
    } else {
      alert('Okay!')
    }
  }

}
</script>

<style lang="scss" scoped>

</style>
