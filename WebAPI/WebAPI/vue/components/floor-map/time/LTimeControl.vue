<template>
  <div class="control">
    <v-container>
      <v-menu
        ref="menu"
        v-model="menu"
        :close-on-content-click="false"
        :return-value.sync="time"
        transition="scale-transition"
        offset-y
      >
        <template v-slot:activator="{ on }">
          <v-text-field
            v-model="timeTemp"
            :label="label"
            :dark="false"
            :light="true"
            :dense="true"
            :prepend-icon="icon"
            readonly
            hide-details="auto"
            v-on="on"
            @input="value => update(value)"
          />
        </template>
        <v-time-picker
          v-model="timeTemp"
          @click:minute="$refs.menu.save(timeTemp)"
        />
      </v-menu>
    </v-container>
  </div>
</template>

<script lang="ts">
import Vue from 'vue'
export default Vue.extend({
  props: {
    label: { type: String, default: 'Time' },
    icon: { type: String, default: 'mdi-clock' },
    time: { type: String, default: '' }
  },
  data () {
    return {
      timeTemp: '',
      menu: false
    }
  },
  watch: {
    time: {
      handler (value) {
        this.timeTemp = value
      },
      immediate: true
    }
  },
  methods: {
    update (time: string) {
      this.$emit('update:time', time)
    }
  }
})
</script>
