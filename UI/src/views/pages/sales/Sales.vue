<template>
  <v-container fill-height>
    <v-layout column>
      <v-flex shrink>
        <v-card-text>
          <div class="text-center display-1 content-text">
            {{ $t('pages.sales.title') }}
          </div>
        </v-card-text>
      </v-flex>
      <v-flex>
        <v-card-text>
          <p class="title content-text">
            {{ $t('pages.sales.content-text') }}
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
export default class Sales extends Vue {

}
</script>
