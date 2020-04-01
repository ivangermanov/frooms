<template>
  <v-container>
    <v-row justify="center">
      <loader :loading="loading" />

      <v-dialog v-model="dialog" :fullscreen="$vuetify.breakpoint.xs" max-width="950">
        <v-card>
          <v-card-title class="headline">
            Room filter
          </v-card-title>
          <v-card-text>
            <filter-option :buildings="buildings" />
          </v-card-text>
          <v-card-actions>
            <v-spacer />
            <v-btn color="green darken-1" text @click="dialog = false">
              Cancel
            </v-btn>
            <v-btn color="green darken-1" text @click="dialog = false">
              Search
            </v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </v-container>
</template>

<script>
import Loader from './Loader.vue'
import FilterOption from './FilterOption.vue'

export default {

  components: { Loader, FilterOption },

  data () {
    return {
      loading: true,
      dialog: false,
      buildings: [
        {
          id: 1,
          name: 'R1',
          campus: 'ICT',
          address: 'Rachelsmolen 1'
        },
        {
          id: 2,
          name: 'R2',
          campus: 'Psychology',
          address: 'Rachelsmolen 2'
        },
        {
          id: 3,
          name: 'R3',
          campus: 'Business',
          address: 'Rachelsmolen 3'
        }
      ]
    }
  },

  mounted () {
    this.fetchData()
    console.log(this.$vuetify.breakpoint)
  },

  methods: {
    fetchData () {
      // do some fetching
      setTimeout(() => {
        this.loading = false
        this.dialog = true
      }, 1000)
    }
  }
}
</script>
