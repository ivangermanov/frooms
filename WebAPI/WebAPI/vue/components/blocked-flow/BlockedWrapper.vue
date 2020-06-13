<template>
  <fragment>
    <div v-if="isBlocked" class="text-center">
      <v-dialog
        v-model="dialog"
        :fullscreen="$vuetify.breakpoint.xs"
        max-width="500"
        persistent
        no-click-animation
      >
        <v-card>
          <v-card-title color="primary" primary-title>
            Forbidden
          </v-card-title>

          <v-card-text>
            Your profile is blocked and you cannot make reservations. <br>
            Please contact your system administrator or mail
            <a href="mailto: info@froom.fontys.nl?subject=Unblock request">
              info@froom.fontys.nl
            </a>
          </v-card-text>

          <v-divider />

          <v-card-actions>
            <v-spacer />
            <v-btn color="primary" text to="/">
              Cancel
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </div>
    <slot v-else />
  </fragment>
</template>

<script>
import { mapGetters } from 'vuex'

export default {
  data () {
    return {
      dialog: false
    }
  },
  computed: {
    ...mapGetters({
      isBlocked: 'user/isBlocked'
    })
  },
  beforeMount () {
    this.dialog = this.isBlocked
  }
}
</script>
