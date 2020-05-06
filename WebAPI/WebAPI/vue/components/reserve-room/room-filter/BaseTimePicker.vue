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
      format="24hr"
      full-width
      @change="updateTime"
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
      modal: false
    }
  },

  methods: {
    updateTime (value) {
      this.$emit('update:time', value)
    }
  }
}
</script>
