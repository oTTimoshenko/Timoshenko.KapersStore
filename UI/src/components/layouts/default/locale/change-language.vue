<template>
  <v-select :items="languages"
            v-model="languageSelected"
            item-text="localeKey"
            item-value="localeName"
            hide-details
            auto-select-first
            width="50px">
    <template v-slot:item="data">
      <template v-if="typeof data.item !== 'object'">
        <v-list-item-content v-text="data.item"></v-list-item-content>
      </template>
      <template v-else>
        <v-list-item-avatar size="15s">
          <v-icon :color="data.item.iconColor">
            {{data.item.icon}}
          </v-icon>
        </v-list-item-avatar>
        <v-list-item-content dense>
          <v-list-item-title>{{$t(data.item.localeKey)}}</v-list-item-title>
        </v-list-item-content>
      </template>
    </template>
  </v-select>
</template>

<script lang="ts">
import Vue from "vue";
import { Component, Prop, Watch } from "vue-property-decorator";
import { isNull, isNullOrUndefined } from 'util';

@Component({})
export default class Login extends Vue {
  languages: any[] = [
    {localeName: 'ru', localeKey: 'RU', icon: 'fa-telegram', iconColor: 'red'},
    {localeName: 'ua', localeKey: 'UA', icon: 'fa-telegram', iconColor: 'yellow'}
  ];
  languageSelected: any = null;

  created() {
    this.languageSelected = this.$i18n.locale 
                              ? this.languages.find(l => l.localeName === this.$i18n.locale)
                              : this.languages.find(l => l.localeName === 'ru');
  }

  @Watch('languageSelected')
  onLanguageChanged(value: string) {
    debugger;
    if(isNullOrUndefined(value))
      this.$i18n.locale = 'ru'
    else
      this.$i18n.locale = value;

  }
}
</script>

<style lang="scss" scoped>
  
</style>
