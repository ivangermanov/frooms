<template>
  <v-dialog v-model="dialog" persistent max-width="290" :fullscreen="$vuetify.breakpoint.xs">
    <template v-slot:activator="{ on }">
      <v-btn icon v-on="on">
        <v-icon>mdi-cog</v-icon>
      </v-btn>
    </template>
    <v-card>
      <v-toolbar dark color="primary">
        <v-btn icon dark @click="cancelSettings">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <v-toolbar-title>Settings</v-toolbar-title>
        <v-spacer />
        <v-toolbar-items>
          <v-btn dark text @click="updateSettings">
            Save
          </v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-list three-line subheader>
        <v-subheader>Chart Controls</v-subheader>
        <v-list-item>
          <v-list-item-content>
            <v-text-field
              v-model="localItems"
              type="number"
              label="Item Limit"
              outlined
            />
          </v-list-item-content>
        </v-list-item>
        <v-list-item>
          <v-list-item-content>
            <date-picker ref="startSetting" :date.sync="localStart" label="Pick a start date" />
          </v-list-item-content>
        </v-list-item>
        <v-list-item>
          <v-list-item-content>
            <date-picker ref="endSetting" :date.sync="localEnd" label="Pick a end date" />
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-card>
  </v-dialog>
</template>

<script>
import moment from 'moment'
import DatePicker from '@/components/base/BaseDatePickerText.vue'

export default {
  components: { DatePicker },

  props: {
    items: {
      type: Number,
      required: true
    },
    start: {
      type: String,
      required: true
    },
    end: {
      type: String,
      required: true
    }
  },

  data () {
    return {
      dialog: false,
      localItems: this.items,
      localStart: moment(this.start),
      localEnd: moment(this.end)
    }
  },

  methods: {
    updateSettings () {
      this.$emit('update:items', parseInt(this.localItems))
      this.$emit('update:start', this.localStart.toISOString(true))
      this.$emit('update:end', this.localEnd.toISOString(true))
      this.$emit('update-settings')
      this.dialog = false
    },
    async cancelSettings () {
      this.localItems = await this.items
      this.localStart = await moment(this.start)
      this.localEnd = await moment(this.end)
      this.$refs.startSetting.cancelUpdate()
      this.$refs.endSetting.cancelUpdate()
      this.dialog = false
    }
  }
}
</script>
