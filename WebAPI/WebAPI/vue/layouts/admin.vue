<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" :mini-variant="miniVariant" fixed app>
      <v-list>
        <v-list-item
          v-for="(item, i) in items"
          :key="i"
          :to="item.to"
          router
          exact
        >
          <v-list-item-action>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title v-text="item.title" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
    <v-app-bar dense app>
      <v-app-bar-nav-icon @click.stop="drawer = !drawer" />
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <v-menu offset-y :close-on-content-click="false">
        <template v-slot:activator="{ on, attrs }">
          <v-btn
            v-bind="attrs"
            v-on="on"
          >
            <v-icon class="pr-2">
              mdi-account
            </v-icon>
            {{ getGivenName }}
          </v-btn>
        </template>
        <v-list dense>
          <v-list-item>
            <v-list-item-content class="pa-0">
              <v-switch
                v-model="$vuetify.theme.dark"
                prepend-icon="mdi-theme-light-dark"
                class="pa-0"
              />
            </v-list-item-content>
          </v-list-item>
          <v-list-item to="/">
            <v-list-item-icon>
              <v-icon>
                mdi-home
              </v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              Home
            </v-list-item-content>
          </v-list-item>
          <v-list-item href="/api/logout">
            <v-list-item-icon>
              <v-icon>
                mdi-logout
              </v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              Logout
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-menu>
    </v-app-bar>
    <v-content>
      <nuxt />
    </v-content>
  </v-app>
</template>

<script lang="ts">
import { mapGetters } from 'vuex'

export default {
  middleware: ['user', 'admin'],
  data () {
    return {
      drawer: false,
      items: [
        {
          icon: 'mdi-view-dashboard',
          title: 'Overview',
          to: '/admin'
        }
      ],
      miniVariant: false,
      title: 'Froom'
    }
  },

  computed: {
    ...mapGetters({
      getGivenName: 'user/getGivenName'
    })
  }
}
</script>
