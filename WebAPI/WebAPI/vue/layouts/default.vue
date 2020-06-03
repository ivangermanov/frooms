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
      <div class="d-flex mr-4">
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <span class="d-flex" v-on="on">
              <v-icon class="pr-2">
                mdi-theme-light-dark
              </v-icon>
              <v-switch v-model="$vuetify.theme.dark" class="switch" />
            </span>
          </template>
          <span>Dark mode</span>
        </v-tooltip>
      </div>
      <v-tooltip v-if="isAdmin" bottom>
        <template v-slot:activator="{ on }">
          <span class="d-flex" v-on="on">
            <v-btn to="/admin">
              <v-icon class="pr-2">mdi-view-dashboard</v-icon>
              Admin
            </v-btn>
          </span>
        </template>
        <span>Admin</span>
      </v-tooltip>
      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <span class="d-flex ml-2" v-on="on">
            <a href="/api/logout">
              <v-btn>
                <v-icon class="pr-2">mdi-logout</v-icon>
                Logout
              </v-btn>
            </a>
          </span>
        </template>
        <span>Logout</span>
      </v-tooltip>
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
          icon: 'mdi-chart-bubble',
          title: 'Floor map',
          to: '/floor-map'
        },
        {
          icon: 'mdi-briefcase-search',
          title: 'Reserve a room',
          to: '/reserve-room'
        }
      ],
      miniVariant: false,
      title: 'Froom Dashboard'
    }
  },
  computed: {
    ...mapGetters({
      isAdmin: 'user/isAdmin'
    })
  }
})
</script>
<style scoped>
  .switch {
    height: 25px;
    align-items: initial;
  }
</style>
