<template>
  <v-list>
    <v-list-item
      v-for="(subscribe, index) in subscribes"
      :key="index">
      <v-layout column>

      
        <v-layout align-center>
          <v-flex>
            <span class="subtitle-1">{{ subscribe.name }}</span>
          </v-flex>
          <v-flex shrink mx-7>
            <span class="subtitle-1">{{ $t(subscribe.price + ' руб.') }}</span>
          </v-flex>
          <v-flex shrink>
            <v-btn class="kaper-buy-button" color="red">
              Buy
              <v-icon right>fa-shopping-cart</v-icon>
            </v-btn>
          </v-flex>
        </v-layout>
        <v-divider></v-divider>
      </v-layout>
    </v-list-item>
  </v-list>
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
