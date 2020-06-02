<template>
  <v-card
    max-width="500"
    class="mx-auto"
  >
    <v-toolbar
      color="primary"
      dark
    >
      <v-toolbar-title>Notifications</v-toolbar-title>
    </v-toolbar>
    <v-list flat>
      <v-list-item-group>
        <template v-if="loading">
          <div class="text-center">
            <v-progress-circular
              indeterminate
              color="primary"
            />
          </div>
        </template>

        <template v-else-if="!loading && notifications.length === 0">
          <v-list-item>
            <v-list-item-content>
              <v-list-item-title>No notifications yet!</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </template>

        <template v-for="(notification, index) in notifications" v-else>
          <v-list-item :key="notification.id" :disabled="!notification.isNew">
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
              <v-tooltip bottom>
                <template v-slot:activator="{ on }">
                  <span class="d-flex" v-on="on">
                    <v-btn
                      icon
                      :disabled="!notification.isNew"
                      color="primary"
                      @click="markNotificationRead(notification.id, index)"
                    >
                      <v-icon v-show="notification.isNew" color="primary">
                        mdi-check
                      </v-icon>
                    </v-btn>
                  </span>
                </template>
                <span>Mark as read</span>
              </v-tooltip>
            </v-list-item-action>
          </v-list-item>
          <v-divider
            v-if="index + 1 < notifications.length"
            :key="index"
          />
        </template>
      </v-list-item-group>
    </v-list>
  </v-card>
</template>

<script>
import { RepositoryFactory } from '@/api/repositoryFactory'

const UserRepository = RepositoryFactory.user

export default {
  data: () => ({
    notifications: [],
    loading: true,
    timer: ''
  }),

  beforeMount () {
    this.fetchNotifications()
    this.timer = setInterval(this.fetchNotifications, 5000)
  },

  mounted () {
    this.loading = true
  },

  beforeDestroy () {
    clearInterval(this.timer)
  },

  methods: {
    async fetchNotifications () {
      const { data } = await UserRepository.getNotifications()
      this.notifications = data
      this.loading = false
    },

    async markNotificationRead (notificationId, index) {
      await UserRepository.markNotificationRead(notificationId)

      const updatedNotifications = [...this.notifications]

      updatedNotifications[index] =
      { ...updatedNotifications[index], isNew: false }

      this.notifications = updatedNotifications
    }
  }
}
</script>
