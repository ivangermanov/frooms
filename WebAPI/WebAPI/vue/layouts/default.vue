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
      <v-btn icon @click.stop="miniVariant = !miniVariant">
        <v-icon>mdi-{{ `chevron-${miniVariant ? "right" : "left"}` }}</v-icon>
      </v-btn>
      <v-toolbar-title v-text="title" />
      <v-spacer />
      <div class="d-flex mr-4">
        <v-tooltip bottom>
          <template v-slot:activator="{ on }">
            <span class="d-flex" v-on="on">
              <v-icon class="pr-2">
                mdi-theme-light-dark
              </v-icon>
              <v-switch v-model="$vuetify.theme.dark" class="switch pr-4" :hint="`Dark mode`" />
            </span>
          </template>
          <span>Dark mode</span>
        </v-tooltip>
      </div>
      <v-tooltip bottom>
        <template v-slot:activator="{ on }">
          <span class="d-flex" v-on="on">
            <v-icon>mdi-logout</v-icon>
            <a href="/api/logout">
              <v-btn>
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
import { IUser } from 'types'
import { mapMutations } from 'vuex'
import { RepositoryFactory } from '@/api/repositoryFactory'
const UserRepository = RepositoryFactory.user

export default Vue.extend({
  data () {
    return {
      drawer: false,
      items: [
        {
          icon: 'mdi-apps',
          title: 'Welcome',
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
      title: 'Froom'
    }
  },
  async created () {
    const data = await this.getUserData()
    console.log(data)
    this.setUser(data)
  },
  methods: {
    async getUserData () {
      const { data: info }: {data: IUser} = await UserRepository.getUserInfo()
      const { data: roles }: {data: Array<string>} = await UserRepository.getUserRoles()
      info.role = roles
      return info
    },
    ...mapMutations({
      setUser: 'user/setUser'
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
