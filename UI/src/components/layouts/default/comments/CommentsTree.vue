<template>
  <v-container grid-list-md fill-height>
    <v-layout column>
      <v-card-title >
        <span class="headline">{{$t('Comments (' + commentsTree.commentsCount + ')')}}</span>
      </v-card-title>
      <template v-for="(commentsGroup, index) in commentsTree.commentsGroups">
        <comments-group :commentsGroup="commentsGroup" :key="index">
        </comments-group>
      </template>

      <v-divider></v-divider>

      <add-comment></add-comment>
    </v-layout>
  </v-container>

</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator'

import CommentsGroup from './comments-group.vue'
import AddComment from './add-comment.vue'

import { KaperComment, KaperCommentsGroup, KaperCommentsTree } from './types'


@Component({
  components: {
    CommentsGroup,
    AddComment
  }
})
export default class CommentsTree extends Vue {
  @Prop() commentsTree!: KaperCommentsTree;
}

</script>
