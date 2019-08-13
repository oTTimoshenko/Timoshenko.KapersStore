<template>
  <v-container grid-list-md fill-height>
    <v-layout column>
      <v-flex shrink>
        <v-layout column>
          <v-flex shrink>
            <v-card-text>
              <div class="text-center display-1 content-text">
                {{ $t('Details of Kaper #' + kaperId)}}
              </div>
            </v-card-text>
          </v-flex>
          <v-flex>
            <v-card-text>
              <p class="title content-text">
                {{ $t('pages.kapers.content-text.part1') }}
              </p>
              <p class="title content-text">
                {{ $t('pages.kapers.content-text.part2') }}
              </p>
            </v-card-text>
          </v-flex>
        </v-layout>
      </v-flex>
      <v-flex my-5>
        <v-divider insite></v-divider>
      </v-flex>
      <v-flex>
        <kaper-subscribes-list :subscribes="subscribes"></kaper-subscribes-list>
      </v-flex>
      <v-flex my-5>
        <v-divider insite></v-divider>
      </v-flex>
      <v-flex>
        <comments-tree :comments="comments"></comments-tree>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'
import KaperSubscribesList from './kaper-subscribes-list.vue'
import CommentsTree from '@/components/layouts/default/comments/CommentsTree.vue'

@Component({
  components: {
    KaperSubscribesList,
    CommentsTree
  }
})
export default class KapersDetails extends Vue {
  subscribes: any[] = [
    { name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu.', price: '1950 руб.'  },
    { name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu.', price: '1950 руб.'  },
    { name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu.', price: '1950 руб.'  },
    { name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu.', price: '1950 руб.'  },
    { name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu.', price: '1950 руб.'  }
  ]

  comments: any[] = [
    { id: 1, userNickname: 'Andrew0', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 0 },
    { id: 2, userNickname: 'Andrew1', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 1 },
    { id: 3, userNickname: 'Andrew2', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 1 },
    { id: 4, userNickname: 'Andrew3', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 0 },
    { id: 5, userNickname: 'Andrew4', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 4 },
    { id: 6, userNickname: 'Andrew5', date: 'March 2019, 18:46', text: 'Hi everyone', parentId: 0 },
  ]

  get kaperId() {
    return +this.$route.params.kaperId;
  }
}
</script>
