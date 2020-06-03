<template>
  <v-dialog v-model="dialog" persistent max-width="290" :fullscreen="$vuetify.breakpoint.xs">
    <template v-slot:activator="{ on }">
      <v-btn icon v-on="on">
        <v-icon>mdi-cog</v-icon>
      </v-btn>
    </template>
    <v-card class="px-4">
      <v-card-title class="headline">
        Chart Settings
      </v-card-title>
      <v-text-field
        v-model="localItems"
        type="number"
        label="Amount of Items"
        outlined
      />
      <date-picker ref="startSetting" :date.sync="localStart" label="Pick a start date" />
      <date-picker ref="endSetting" :date.sync="localEnd" label="Pick a end date" />
      <v-card-actions>
        <v-spacer />
        <v-btn color="primary" text @click="updateSettings">
          Save
        </v-btn>
        <v-btn color="primary" text @click="cancelSettings">
          Cancel
        </v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import DatePicker from '@/components/base/BaseDatePickerText.vue'

export default {
  components: { DatePicker },

  props: {
    items: {
      type: Number,
      required: true
    },
    start: {
      type: Object,
      required: true
    },
    end: {
      type: Object,
      required: true
    }
  },

  data () {
    return {
      dialog: false,
      localItems: this.items,
      localStart: this.start,
      localEnd: this.end
    }
  },

  methods: {
    updateSettings () {
      this.$emit('update:items', parseInt(this.localItems))
      this.$emit('update:start', this.localStart)
      this.$emit('update:end', this.localEnd)
      this.$emit('update-settings')
      this.dialog = false
    },
    async cancelSettings () {
      this.localItems = await this.items
      this.localStart = await this.start
      this.localEnd = await this.end
      this.$refs.startSetting.cancelUpdate()
      this.$refs.endSetting.cancelUpdate()
      this.dialog = false
    }
  }
}
</script>
