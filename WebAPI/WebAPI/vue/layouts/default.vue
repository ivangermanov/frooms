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
      <notifications-menu />
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
          <v-list-item v-if="isAdmin" to="/admin">
            <v-list-item-icon>
              <v-icon>
                mdi-view-dashboard
              </v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              Admin
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
      <portal-target name="modals" />
    </v-content>
  </v-app>
</template>

<script lang="ts">
import Vue from 'vue'
import { mapGetters } from 'vuex'
import NotificationsMenu from '~/components/notifications/NotificationsMenu.vue'

export default Vue.extend({
  components: {
    NotificationsMenu
  },
  middleware: 'user',
  data () {
    return {
      drawer: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Dashboard',
          to: '/'
        },
        {
          icon: 'mdi-map',
          title: 'Floor map',
          to: '/floor-map'
        },
        {
          icon: 'mdi-calendar',
          title: 'Reserve a room',
          to: '/reserve-room'
        }
      ],
      miniVariant: false,
      title: 'Froom'
    }
  },
  computed: {
    ...mapGetters({
      isAdmin: 'user/isAdmin',
      getGivenName: 'user/getGivenName'
    })
  }
})
</script>
