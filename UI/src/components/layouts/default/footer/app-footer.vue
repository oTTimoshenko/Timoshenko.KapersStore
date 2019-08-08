<template>
  <v-footer padless 
						app>
    <v-flex text-center
            md12>
      {{ new Date().getFullYear() }} — <strong>{{$t('app.footer.title')}}</strong>
    </v-flex>
  </v-footer>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component({})
export default class AppFooter extends Vue {

}

</script>
