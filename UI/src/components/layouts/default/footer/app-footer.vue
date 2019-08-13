<template>
  <v-footer padless 
						app>
    <v-flex text-center
            md12>
      {{ new Date().getFullYear() }} — <strong>{{$t('app.footer.title')}}</strong>
    </v-flex>
    <notification/>
  </v-footer>
</template>

<script lang="ts">

import Vue from 'vue';
import { Component } from 'vue-property-decorator';

import Notification from '@/components/layouts/default/notifications/snackbar/notification.vue';

@Component({
  components: {
    Notification
  }
})
export default class AppFooter extends Vue {

}

</script>
