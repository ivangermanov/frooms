<template>
  <div v-if="isBlocked === false">
    <portal to="modals">
      <reserve-modal />
    </portal>
  </div>
  <div v-else>
    <template>
      <div class="text-center">
        <v-dialog
          v-model="dialog"
          :fullscreen="$vuetify.breakpoint.xs"
          max-width="500"
          persistent
          no-click-animation
        >
          <v-card>
            <v-card-title
              color="primary"
              primary-title
            >
              Forbidden
            </v-card-title>

            <v-card-text>
              Your profile is blocked and you cannot make reservations. Please contact your system administrator.
            </v-card-text>

            <v-divider />

            <v-card-actions>
              <v-spacer />
              <v-btn
                color="primary"
                text
                to="/"
              >
                Cancel
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-dialog>
      </div>
    </template>
  </div>
</template>

<script>
import ReserveModal from '~/components/reserve-room/ReserveModal.vue'

export default {
  components: { ReserveModal },
  data () {
    return {
      isBlocked: this.$store.state.user.info.isBlocked,
      dialog: undefined
    }
  },

  beforeMount () {
    this.dialog = true
  }
}
</script>
