<template>
  <v-dialog
    :ref="`dialog-time-picker-${_uid}`"
    v-model="modal"
    :return-value.sync="time"
    width="290px"
  >
    <template v-slot:activator="{ on }">
      <v-text-field
        :value="time"
        :label="label"
        prepend-icon="mdi-clock-outline"
        readonly
        :rules="rules"
        v-on="on"
      />
    </template>
    <v-time-picker
      v-if="modal"
      :value="time"
      :format="'24hr'"
      full-width
      scrollable
      @click:hour="updateHour"
      @click:minute="updateMinute"
    >
      <v-spacer />
      <v-btn text color="primary" @click="modal = false">
        Cancel
      </v-btn>
      <v-btn text color="primary" @click="$refs[`dialog-time-picker-${_uid}`].save(time)">
        OK
      </v-btn>
    </v-time-picker>
  </v-dialog>
</template>

<script>

export default {
  props: {
    time: {
      type: String,
      required: true
    },
    label: {
      type: String,
      required: false,
      default () {
        return 'Pick a time'
      }
    },
    rules: {
      type: Array,
      required: false,
      default () {
        return []
      }
    }
  },

  data () {
    return {
      modal: false,
      hour: null,
      minute: null
    }
  },

  computed: {
    timeIsReady () {
      return this.hour != null && this.minute != null
    }
  },

  methods: {
    padNumber (number) {
      return number < 10 ? `0${number}` : `${number}`
    },

    updateHour (value) {
      this.hour = this.padNumber(value)
      if (this.timeIsReady) {
        this.updateTime()
      }
    },

    updateMinute (value) {
      this.minute = this.padNumber(value)
      if (this.timeIsReady) {
        this.updateTime()
      }
    },

    updateTime () {
      this.$emit('update:time', `${this.hour}:${this.minute}`)
    }
  }
}
</script>
