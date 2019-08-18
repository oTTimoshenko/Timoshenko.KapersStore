<template>
  <v-container my-6 pa-2>
    <v-card>

      <v-card-text>
        <v-textarea :label="$t('New comment')"
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
        <v-btn right color="red">
          {{$t('Add comment')}}
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-container>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';

@Component({})
export default class AddComment extends Vue {
}

</script>
