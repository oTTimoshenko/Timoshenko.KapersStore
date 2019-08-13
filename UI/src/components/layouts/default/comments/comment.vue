<template>
  <v-container pa-2>
    <v-card>
      <v-card-title pa-0 ma-0>
        <v-list two-line subheader pa-0 ma-0>
          <v-list-item pa-0 ma-0>
            <v-list-item-avatar>
              <v-icon x-large>fa-telegram</v-icon>
            </v-list-item-avatar>

            <v-list-item-content>
              <v-list-item-title>
                {{$t(comment.userNickname)}}
              </v-list-item-title>
              <v-list-item-subtitle>
                {{$t(comment.date)}}
              </v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-card-title>

      <v-card-text>
        {{$t(comment.text)}}
      </v-card-text>

      <v-card-actions>
        <v-btn right>
          {{$t('Respond')}}
          <v-icon>fa-times</v-icon>
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class Comment extends Vue {
  @Prop() comment!: any;
}

</script>
