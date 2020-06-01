<template>
  <v-dialog
    v-model="dialog"
    persistent
    width="290px"
  >
    <template v-slot:activator="{ on }">
      <v-text-field
        :value="displayedDate"
        :label="label"
        prepend-icon="mdi-calendar"
        readonly
        v-on="on"
      />
    </template>
    <v-date-picker
      v-model="localDate"
      scrollable
    >
      <v-spacer />
      <v-btn text color="primary" @click="cancelUpdate">
        Cancel
      </v-btn>
      <v-btn text color="primary" @click="updateDate">
        OK
      </v-btn>
    </v-date-picker>
  </v-dialog>
</template>

<script>
import moment from 'moment'

export default {
  props: {
    date: {
      type: Object,
      required: true
    },
    label: {
      type: String,
      required: false,
      default () {
        return 'Pick a date'
      }
    }
  },

  data () {
    return {
      dialog: false,
      localDate: this.date.format('YYYY-MM-DD')
    }
  },

  computed: {
    displayedDate () {
      return moment(this.localDate).format('DD-MM-YYYY')
    }
  },

  methods: {
    updateDate () {
      this.$emit('update:date', moment(this.localDate))
      this.dialog = false
    },
    cancelUpdate () {
      this.localDate = this.date.format('YYYY-MM-DD')
      this.dialog = false
    }
  }
}
</script>
