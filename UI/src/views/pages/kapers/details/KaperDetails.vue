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
        <kaper-subscriptions-list :subscriptions="kaperDetails.subscriptions"></kaper-subscriptions-list>
      </v-flex>
      <v-flex my-5>
        <v-divider insite></v-divider>
      </v-flex>
      <v-flex>
        <comments-tree :commentsTree="commentsTree"></comments-tree>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'
import KaperSubscriptionsList from './kaper-details-subscriptions-list.vue'
import CommentsTree from '@/components/layouts/default/comments/CommentsTree.vue'

import { CartKaper, CartSubscription, CartState } from '@/components/layouts/default/cart/types';
import EventBus from '@/plugins/eventBus'
import { KaperComment, KaperCommentsTree } from '@/components/layouts/default/comments/types';
import apiService from '@/components/layouts/default/helpers/services/apiService'

@Component({
  components: {
    KaperSubscriptionsList,
    CommentsTree
  }
})
export default class KapersDetails extends Vue {
  kaperDetails: any = {}
  //   id: 1,
  //   name: 'Kaper1',
  //   subscriptions: [
  //     { id: 1, name: 'Lorem ipsum dolor sit amet', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ', price: 1950, days: 7  },
  //     { id: 2, name: 'Lorem ipsum dolor sit amet', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ', price: 1950, days: 14  },
  //     { id: 3, name: 'Lorem ipsum dolor sit amet', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ', price: 1950, days: 10  },
  //     { id: 4, name: 'Lorem ipsum dolor sit amet', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ', price: 1950, days: 21  },
  //     { id: 5, name: 'Lorem ipsum dolor sit amet', description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. ', price: 1950, days: 31  }
  // ]}

  comments: KaperComment[] = []
  //   new KaperComment(1, 0, 'Andrew0', 'March 2019, 18:46', 'Hi everyone'),
  //   new KaperComment(2, 1, 'Andrew1', 'March 2019, 18:46', 'Hi everyone'),
  //   new KaperComment(3, 1, 'Andrew2', 'March 2019, 18:46', 'Hi everyone'),
  //   new KaperComment(4, 0, 'Andrew3', 'March 2019, 18:46', 'Hi everyone'),
  //   new KaperComment(5, 4, 'Andrew4', 'March 2019, 18:46', 'Hi everyone'),
  //   new KaperComment(6, 0, 'Andrew5', 'March 2019, 18:46', 'Hi everyone'),
  // ];

  commentsTree: KaperCommentsTree = new KaperCommentsTree();

  created() {
    apiService.get('kapers', this.kaperId.toString()).then(response => {
      this.kaperDetails = response.data;
    });

    apiService.get('kapers', this.kaperId.toString() + '/comments').then(response => {
      this.comments = response.data.map(c => new KaperComment(c.id, c.parentId, c.userNickname, new Date(c.date).toLocaleString(), c.text));
      this.commentsTree = new KaperCommentsTree(this.comments);
    });

    EventBus.$off(['kaper-subscriptions:add-to-cart', 'comments:added', 'comments:remove']);

    EventBus.$on('kaper-subscriptions:add-to-cart', this.addKaperToCart);
    EventBus.$on('comments:added', this.addComment);
    EventBus.$on('comments:remove', this.removeComment);
  }

  addComment(commentData: any) {
    debugger
    const commentToSendToServer = {
      parentId: commentData.parentId,
      text: commentData.text,
      userId: this.$store.state.userStore.user.id,
      kaperId: this.kaperId
    }
    apiService.post('kapers', '/addComment', commentToSendToServer).then(response => {
      const data = response.data;
      const comment = new KaperComment(data.id, data.parentId, data.userNickname, new Date(data.date).toLocaleString(), data.text);
      this.commentsTree.addComment(comment);
    });
  }

  removeComment(id: number) {
    apiService.post('kapers', '/removeComment', { id }).then(response => {
      this.commentsTree.removeComment(id);
    });
  }

  addKaperToCart(subscriptionId: number) {
    const cartKaper = new CartKaper(this.kaperDetails.id, this.kaperDetails.name, 
      this.kaperDetails.subscriptions.filter(s => s.id === subscriptionId)
                                        .map(s => new CartSubscription(s.id, s.name, s.price, s.days)));

    EventBus.$emit('cart:item-added', cartKaper);
  }

  get kaperId() {
    return +this.$route.params.kaperId;
  }
}
</script>
