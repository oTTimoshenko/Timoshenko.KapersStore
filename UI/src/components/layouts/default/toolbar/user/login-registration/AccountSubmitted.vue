<template>
  <v-container fill-height>
    <loading v-if="!isConfirmed"></loading>
    <v-layout align-center column v-else>
      <v-flex shrink>
        <v-icon x-large>fa-telegram</v-icon>
      </v-flex>
      <v-flex grow>
        <v-card-text class="headline text-md-center">
          {{$t('Ur account successfully confirmed! Let`s log in')}}
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

@Component({
  components: {
    LoginForm,
    Loading
  }
})
export default class AccountSubmitted extends Vue {
  isConfirmed: boolean = false;

  get email() {
    return this.$route.params.email;
  }

  get code() {
    return this.$route.params.code;
  }

  created() {
    apiService.post('users', 'confirmEmail', { email: this.email, code: this.code  })
                .catch(error => this.$router.push({name: 'home'}))
                .then(response => this.isConfirmed = true);
  }
}
</script>

<style lang="scss" scoped>

</style>
