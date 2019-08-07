<template>
  <v-app id="inspire">
    <v-navigation-drawer
      v-model="drawer"
      app
      clipped>
      <v-list dense>
        <v-list-item
          v-for="item in items"
          :key="item.text"
          @click=""
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>
              {{ item.text }}
            </v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-subheader class="mt-4 grey--text text--darken-1">{{$t('message')}}</v-subheader>
        <v-list>
          <v-list-item
            v-for="item in items2"
            :key="item.text"
            @click=""
          >
            <v-list-item-avatar>
              <img
                :src="`https://randomuser.me/api/portraits/men/${item.picture}.jpg`"
                alt=""
              >
            </v-list-item-avatar>
            <v-list-item-title v-text="item.text"></v-list-item-title>
          </v-list-item>
        </v-list>
        <v-list-item
          class="mt-4"
          @click=""
        >
          <v-list-item-action>
            <v-icon color="grey darken-1">add_circle_outline</v-icon>
          </v-list-item-action>
          <v-list-item-title class="grey--text text--darken-1">Buy subscription</v-list-item-title>
        </v-list-item>
        <v-list-item @click="">
          <v-list-item-action>
            <v-icon color="grey darken-1">settings</v-icon>
          </v-list-item-action>
          <v-list-item-title class="grey--text text--darken-1">Account Settings</v-list-item-title>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar
      app
      clipped-left
      color="red"
      dense
    >
      <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
      <v-icon class="mx-4">featured_play_list</v-icon>
      <v-toolbar-title class="mr-12 align-center">
        <span class="title">Title</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <v-layout
        align-center
        style="max-width: 650px"
      >
        <v-text-field
          :append-icon-cb="() => {}"
          placeholder="Search..."
          single-line
          append-icon="search"
          color="white"
          hide-details
        ></v-text-field>
      </v-layout>
    </v-app-bar>

    <v-content>
      <v-container fill-height>

      </v-container>
    </v-content>
  </v-app>
</template>


<script>
  export default {
    props: {
      source: String,
    },
    data: () => ({
      drawer: null,
      items: [
        { icon: 'featured_play_list', text: 'Page1' },
        { icon: 'featured_play_list', text: 'Page2' },
        { icon: 'featured_play_list', text: 'Page3' },
        { icon: 'featured_play_list', text: 'Page4' },
        { icon: 'featured_play_list', text: 'Page5' },
      ],
      items2: [
        { picture: 28, text: 'Kaper1' },
        { picture: 38, text: 'Kaper2' },
        { picture: 48, text: 'Kaper3' },
        { picture: 58, text: 'Kaper4' },
        { picture: 78, text: 'Kaper5' },
      ],
    }),
    created () {
      this.$vuetify.theme.dark = true
    },
  }
</script>


