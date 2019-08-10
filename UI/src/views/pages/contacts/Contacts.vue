<template>
  <v-container fill-height>
    <v-layout column>
      <v-flex shrink>
        <v-card-text>
          <div class="text-center display-1 content-text">
            {{ $t('pages.contacts.title') }}
          </div>
        </v-card-text>
      </v-flex>
      <v-flex>
        <v-card-text>
          <p class="title content-text">
            {{ $t('pages.contacts.content-text') }}
          </p>
          <p v-for="(contact, index) in contacts" :key="index">
            <v-layout align-center justify-start>
              <v-flex shrink mx-2><v-icon :color="contact.color" size="30">{{contact.icon}}</v-icon></v-flex>
              <v-flex shrink mx-2><span class="title">{{contact.title}}</span></v-flex>
              <v-flex shrink mx-2><span class="subtitle-1">{{contact.description}}</span></v-flex>
            </v-layout>
          </p>
        </v-card-text>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

@Component({})
export default class Contacts extends Vue {
  contacts: any[] = [
    { title: 'E-mail:', description: 'email@mail.com', icon: 'fa-at', color: 'red' },
    { title: 'Telegram:', description: '@telegram', icon: 'fa-telegram', color: 'blue' }
  ]
}
</script>
