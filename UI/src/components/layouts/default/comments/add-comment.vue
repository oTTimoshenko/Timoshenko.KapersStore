<template>
  <v-container my-6 pa-2>
    <v-card>

      <v-card-text>
        <v-textarea ref="comment"
                    :label="$t('New comment')"
                    :placeholder="$t('Put here your text...')"
                    rows="7"
                    counter="500"
                    color="red"
                    outlined
                    no-resize
                    required
                    v-model="text"
                    >
        </v-textarea>
      </v-card-text>

      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="addComment" right color="red" :disabled="text.length <= 0">
          {{$t('Add comment')}}
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
export default class AddComment extends Vue {
  text: string = '';

  addComment() {
    EventBus.$emit('comments:added', { text: this.text, parentId: null});
    this.text = '';
  }
}

</script>
