<template>
  <v-container grid-list-md fill-height>
    <v-layout column>
      <v-flex shrink>
        <v-layout column>
          <v-flex shrink>
            <v-card-text>
              <div class="text-center display-1 content-text">
                {{ $t('pages.kapers.title') }}
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
      <v-flex mb-5>
        <v-divider insite></v-divider>
      </v-flex>
      <v-flex>
        <v-layout>
          <kapers-list :kapers="kapers"></kapers-list>
        </v-layout>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from 'vue'
import { Prop, Component } from 'vue-property-decorator'
import KapersList from './kapers-list.vue'

@Component({
  components: {
    KapersList
  }
})
export default class Kapers extends Vue {
  kapers: any[] = [
    { id: 1, name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', subscribes: [
                                                                        { name: 'Subscribe1', price: 100 },
                                                                        { name: 'Subscribe2', price: 200 },
                                                                        { name: 'Subscribe3', price: 300 }
                                                                      ],
      description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim. Felis imperdiet proin fermentum leo vel orci. Vel orci porta non pulvinar neque laoreet suspendisse interdum. Justo nec ultrices dui sapien eget. Nullam ac tortor vitae purus. Velit scelerisque in dictum non. Neque laoreet suspendisse interdum consectetur libero id faucibus. Quam quisque id diam vel quam. A cras semper auctor neque vitae tempus. Condimentum mattis pellentesque id nibh. Nunc mattis enim ut tellus elementum sagittis vitae et. Enim eu turpis egestas pretium aenean. Id diam vel quam elementum pulvinar etiam non.', imageSource: 'https://avatars0.githubusercontent.com/u/9064066?v=4&s=460', imageAltText: 'test',  },
    { id: 2, name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', subscribes: [
                                                                      { name: 'Subscribe1', price: 300 },
                                                                      { name: 'Subscribe2', price: 300 },
                                                                      { name: 'Subscribe3', price: 300 }
                                                                    ],
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim. Felis imperdiet proin fermentum leo vel orci. Vel orci porta non pulvinar neque laoreet suspendisse interdum. Justo nec ultrices dui sapien eget. Nullam ac tortor vitae purus. Velit scelerisque in dictum non. Neque laoreet suspendisse interdum consectetur libero id faucibus. Quam quisque id diam vel quam. A cras semper auctor neque vitae tempus. Condimentum mattis pellentesque id nibh. Nunc mattis enim ut tellus elementum sagittis vitae et. Enim eu turpis egestas pretium aenean. Id diam vel quam elementum pulvinar etiam non.', imageSource: 'https://avatars0.githubusercontent.com/u/9064066?v=4&s=460', imageAltText: 'test',  },
    { id: 3, name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', subscribes: [
                                                                      { name: 'Subscribe1', price: 300 },
                                                                      { name: 'Subscribe2', price: 300 },
                                                                      { name: 'Subscribe3', price: 300 }
                                                                    ],
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim. Felis imperdiet proin fermentum leo vel orci. Vel orci porta non pulvinar neque laoreet suspendisse interdum. Justo nec ultrices dui sapien eget. Nullam ac tortor vitae purus. Velit scelerisque in dictum non. Neque laoreet suspendisse interdum consectetur libero id faucibus. Quam quisque id diam vel quam. A cras semper auctor neque vitae tempus. Condimentum mattis pellentesque id nibh. Nunc mattis enim ut tellus elementum sagittis vitae et. Enim eu turpis egestas pretium aenean. Id diam vel quam elementum pulvinar etiam non.', imageSource: 'https://avatars0.githubusercontent.com/u/9064066?v=4&s=460', imageAltText: 'test',  },
    { id: 4, name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', subscribes: [
                                                                      { name: 'Subscribe1', price: 3100 },
                                                                      { name: 'Subscribe2', price: 3020 },
                                                                      { name: 'Subscribe3', price: 300 }
                                                                    ],
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim. Felis imperdiet proin fermentum leo vel orci. Vel orci porta non pulvinar neque laoreet suspendisse interdum. Justo nec ultrices dui sapien eget. Nullam ac tortor vitae purus. Velit scelerisque in dictum non. Neque laoreet suspendisse interdum consectetur libero id faucibus. Quam quisque id diam vel quam. A cras semper auctor neque vitae tempus. Condimentum mattis pellentesque id nibh. Nunc mattis enim ut tellus elementum sagittis vitae et. Enim eu turpis egestas pretium aenean. Id diam vel quam elementum pulvinar etiam non.', imageSource: 'https://avatars0.githubusercontent.com/u/9064066?v=4&s=460', imageAltText: 'test',  },
    { id: 5, name: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit', subscribes: [
                                                                      { name: 'Subscribe1', price: 3030 },
                                                                      { name: 'Subscribe2', price: 3030 },
                                                                      { name: 'Subscribe3', price: 300 }
                                                                    ],
    description: 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. At elementum eu facilisis sed odio morbi quis. Sit amet porttitor eget dolor morbi non arcu. In hac habitasse platea dictumst vestibulum. Nibh tellus molestie nunc non blandit massa enim. Felis imperdiet proin fermentum leo vel orci. Vel orci porta non pulvinar neque laoreet suspendisse interdum. Justo nec ultrices dui sapien eget. Nullam ac tortor vitae purus. Velit scelerisque in dictum non. Neque laoreet suspendisse interdum consectetur libero id faucibus. Quam quisque id diam vel quam. A cras semper auctor neque vitae tempus. Condimentum mattis pellentesque id nibh. Nunc mattis enim ut tellus elementum sagittis vitae et. Enim eu turpis egestas pretium aenean. Id diam vel quam elementum pulvinar etiam non.', imageSource: 'https://avatars0.githubusercontent.com/u/9064066?v=4&s=460', imageAltText: 'test',  }
  ]
}
</script>
