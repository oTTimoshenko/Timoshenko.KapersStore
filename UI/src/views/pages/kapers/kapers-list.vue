<template>
  <v-expansion-panels multiple popout>
    <v-expansion-panel
      v-for="(kaper, index) in Kapers"
      :key="index">
      <v-expansion-panel-header>
        <v-layout align-center>
          <v-flex md1>
            <v-avatar size="46px">
              <img :src="kaper.imageSource"
                   :alt="kaper.altText">
            </v-avatar>
          </v-flex>
          <v-flex>
            <span class="subtitle-1">{{ kaper.name }}</span>
          </v-flex>
        </v-layout>
      </v-expansion-panel-header>
      <v-expansion-panel-content pa-0>
        <v-card flat>
          {{ kaper.description }}
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
  @Prop({type: [], default: []}) kapers!: any[];

  get Kapers() {
    return this.kapers && this.kapers.length > 0 ? this.kapers : [];
  }
}
</script>

<style lang="scss" scoped>
.kaper-buy-button {
  width: 10%;
}
</style>
