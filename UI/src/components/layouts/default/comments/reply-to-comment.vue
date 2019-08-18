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
                    counter="250"
                    color="red"
                    outlined
                    no-resize>
        </v-textarea>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="reply" right color="red">
          {{$t('Reply')}}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class ReplyToComment extends Vue {
  @Prop({default: false}) isReplyToCommentVisible!: boolean;

  closeReply() {
    this.$emit('update:isReplyToCommentVisible', false);
  }

  reply() {
    this.closeReply();
  }
}

</script>
