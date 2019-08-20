<template>
  <v-layout column ma-3>
    <v-flex md12 pa-0>
      <comment :comment="commentsGroup.parent" :replyable="true"/>
    </v-flex>
    <v-flex pa-0 v-for="(comment, index) in commentsGroup.children"
            md11
            offset-md-1
            :key="index">
      <comment :comment="comment"/>
    </v-flex>
  </v-layout>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import Comment from './comment.vue'

import {  KaperCommentsGroup } from './types'

@Component({
  components: {
    Comment
  }
})
export default class CommentsGroup extends Vue {
  @Prop() commentsGroup!: KaperCommentsGroup;
}

</script>
