<template>
  <v-expansion-panels multiple popout>
    <v-expansion-panel
      v-for="(subscribe, index) in subscribes"
      :key="index">
      <v-expansion-panel-header>
        <v-layout align-center>
          <v-flex shrink>
            <span class="subtitle-1">{{ subscribe.name }}</span>
          </v-flex>
          <v-flex>
            <span class="subtitle-1">{{ subscribe.price }}</span>
          </v-flex>
        </v-layout>
      </v-expansion-panel-header>
      <v-expansion-panel-content pa-0>
        <v-card flat>
          {{ subscribe.description }}
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn class="kaper-buy-button" color="red">
              Buy
              <v-icon right>fa-shopping-cart</v-icon>
            </v-btn>
          </v-card-actions>
        </v-card>
        
      </v-expansion-panel-content>
    </v-expansion-panel>
  </v-expansion-panels>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'

@Component({})
export default class KapersList extends Vue {
  @Prop({type: [], default: []}) subscribes!: any[];
}
</script>

<style lang="scss" scoped>

</style>
