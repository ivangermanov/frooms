<template>
  <v-menu
    :close-on-click="closeOnClick"
    :offset-y="offsetY"
    transition="scale-transition"
  >
    <template v-slot:activator="{ on }">
      <v-badge
        :content="newNotifications"
        :value="newNotifications"
        color="primary"
        overlap
        class="ma-3"
      >
        <v-btn
          small
          icon
          v-on="on"
          @click="markNotificationsRead()"
        >
          <v-icon>
            mdi-bell
          </v-icon>
        </v-btn>
      </v-badge>
    </template>
    <v-list>
      <v-list-item
        v-for="(notification, index) in notifications"
        :key="index"
      >
        <v-list-item-icon v-show="notification.isNew">
          <v-icon color="red">
            mdi-new-box
          </v-icon>
        </v-list-item-icon>
        <v-list-item-content>
          <v-list-item-title v-text="notification.title" />
          <v-list-item-subtitle v-text="notification.message" />
        </v-list-item-content>
        <v-list-item-action>
          <v-list-item-action-text v-text="notification.createdDate" />
        </v-list-item-action>
      </v-list-item>
    </v-list>
  </v-menu>
</template>

<script>
import { RepositoryFactory } from '@/api/repositoryFactory'

const UserRepository = RepositoryFactory.user

export default {
  data: () => ({
    notifications: [],
    newNotifications: 0,
    timer: '',
    closeOnClick: true,
    offsetY: true
  }),

  beforeMount () {
    this.fetchNotifications()
    this.timer = setInterval(this.fetchNotifications, 5000)
  },

  beforeDestroy () {
    clearInterval(this.timer)
  },

  methods: {
    async fetchNotifications () {
      const { data } = await UserRepository.getNotifications()
      this.notifications = data
      this.newNotifications = this.notifications.reduce(function (previousValue, currentObject) {
        return previousValue + (currentObject.isNew ? 1 : 0)
      }, 0)
    },

    markNotificationsRead () {
      setTimeout(async () => {
        if (this.notifications.some(notification => notification.isNew === true)) {
          await UserRepository.markNotificationsRead()

          const updatedNotifications = [...this.notifications]

          updatedNotifications.forEach((notification) => { notification.isNew = false })

          this.notifications = updatedNotifications
          this.newNotifications = 0
        }
      }, 500)
    }
  }
}
</script>
