<template>
  <v-dialog
    :ref="`dialog-time-picker-${_uid}`"
    v-model="modal"
    :return-value.sync="timeTemp"
    width="290px"
  >
    <template v-slot:activator="{ on }">
      <v-text-field
        v-model="timeTemp"
        :label="label"
        :prepend-icon="icon"
        readonly
        v-on="on"
      />
    </template>
    <v-time-picker
      v-if="modal"
      v-model="timeTemp"
      :min="min"
      :max="max"
      scrollable
      :format="'24hr'"
      full-width
      @click:minute="$refs[`dialog-time-picker-${_uid}`].save(timeTemp)"
    />
  </v-dialog>
</template>

<script>
export default {
  props: {
    icon: { type: String, default: 'mdi-clock' },
    label: { type: String, default: 'Pick a time' },
    time: { type: String, default: '' },
    min: { type: String, default: '' },
    max: { type: String, default: '' }
  },

  data () {
    return {
      modal: false,
      timeTemp: ''
    }
  },
  watch: {
    time: {
      handler (value) {
        this.timeTemp = value
      },
      immediate: true
    },
    timeTemp: {
      handler () {
        this.update()
      },
      immediate: true
    }
  },
  methods: {
    update () {
      this.$emit('update:time', this.timeTemp)
    }
  }
}
</script>
