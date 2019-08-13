<template>
  <v-container ma-0 pa-0>
    <v-card>
      <v-card-title>
        {{$t('Registration')}}
      </v-card-title>
  
      <v-card-text>
        <v-container grid-list-md>
          <v-layout column>
            <v-text-field :label="$t('Email')">
            
            </v-text-field>
            <v-text-field :label="$t('Nickname')">
            
            </v-text-field>
            <v-text-field :label="$t('Password')">
            
            </v-text-field>
            <v-text-field :label="$t('Confirm Password')">
            
            </v-text-field>
          </v-layout>
        </v-container>
      </v-card-text>
  
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-layout justify-end ma-1>
          <v-btn>
            {{$t('Cancel')}}
          </v-btn>
          <v-btn>
            {{$t('Registrate')}}
          </v-btn>
        </v-layout>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";

@Component({})
export default class RegistrationForm extends Vue {

}
</script>

<style lang="scss" scoped>

</style>
