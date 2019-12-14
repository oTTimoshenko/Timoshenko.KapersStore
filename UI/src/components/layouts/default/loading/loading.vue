<template>
  <v-container class="text-xs-center" fill-height>
    <v-layout align-center justify-center>
      <v-progress-circular
        :size="size"
        :width="width"
        :color="color"
        indeterminate
      ></v-progress-circular>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop } from "vue-property-decorator";

@Component({})
export default class Loading extends Vue {
  @Prop({default: 70, type: Number}) size!: number;
  @Prop({default: 7, type: Number}) width!: number;
  @Prop({default: 'red', type: String}) color!: string;
}
</script>

<style lang="scss" scoped>

</style>
