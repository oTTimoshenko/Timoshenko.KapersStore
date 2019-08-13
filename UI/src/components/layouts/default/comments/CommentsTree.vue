<template>
  <v-container grid-list-md fill-height>
    <v-layout column>
      <v-card-title >
        <span class="headline">{{$t('Comments (' + commentsCount + ')')}}</span>
      </v-card-title>
      <template v-for="(commentsGroup, index) in commentsGroups">
        <comments-group :commentsGroup="commentsGroup" :key="index">
        </comments-group>
      </template>
    </v-layout>
  </v-container>

</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import CommentsGroup from './comments-group.vue'

@Component({
  components: {
    CommentsGroup
  }
})
export default class CommentsTree extends Vue {
  @Prop() comments!: any[];

  get commentsGroups() {
    const parentComments = this.comments.filter(c => c.parentId === 0);

    return parentComments.map(r => { return {...r, ...{children: this.comments.filter(c => c.parentId === r.id)}}});
  }

  get commentsCount() {
    return this.comments.length;
  }
}

</script>
