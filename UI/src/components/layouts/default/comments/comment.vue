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

      <v-card-actions v-if="replyable">
        <v-btn v-if="!isReplyToCommentVisible" right @click="isReplyToCommentVisible = true" color="red">
          {{$t('Respond')}}
        </v-btn>
        <reply-to-comment v-if="isReplyToCommentVisible" :isReplyToCommentVisible.sync="isReplyToCommentVisible"></reply-to-comment>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import ReplyToComment from './reply-to-comment.vue'

@Component({
  components: {
    ReplyToComment
  }
})
export default class Comment extends Vue {
  @Prop() comment!: any;
  @Prop({default: false}) replyable!: boolean;

  isReplyToCommentVisible: boolean = false;
}

</script>
