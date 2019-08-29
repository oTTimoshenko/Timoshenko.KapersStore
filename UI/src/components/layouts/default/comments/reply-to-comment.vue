<template>
  <v-container my-6 pa-2>
    <v-divider></v-divider>
    <v-card flat>
      <v-card-title>
        <v-spacer></v-spacer>
        <v-btn @click="closeReply" small icon color="red">
          <v-icon>fa-times</v-icon>
        </v-btn>
      </v-card-title>
      <v-card-text>
        <v-textarea :label="$t('Comment')"
                    :placeholder="$t('Put here your text...')"
                    rows="7"
                    counter="500"
                    color="red"
                    outlined
                    no-resize
                    v-model="text">
        </v-textarea>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="reply" right color="red" :disabled="text.length <= 0">
          {{$t('Reply')}}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

import EventBus from '@/plugins/eventBus'
import { KaperComment } from '@/components/layouts/default/comments/types';

@Component({})
export default class ReplyToComment extends Vue {
  @Prop() parentId!: number;
  @Prop({default: false}) isReplyToCommentVisible!: boolean;

  text: string = '';

  addComment() {
    EventBus.$emit('comments:added', { text: this.text, parentId: this.parentId});
  }

  closeReply() {
    this.text = '';
    this.$emit('update:isReplyToCommentVisible', false);
  }

  reply() {
    this.addComment();
    this.closeReply();
  }
}

</script>
