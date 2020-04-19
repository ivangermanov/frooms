<template>
  <v-card>
    <v-card-title class="headline">
      Pick Room
    </v-card-title>
    <v-card-text>
      <v-list rounded>
        <v-subheader>Rooms</v-subheader>
        <v-list-item-group v-model="selectedRoomIndex" color="primary">
          <v-list-item
            v-for="(room, i) in rooms"
            :key="i"
          >
            <v-list-item-icon>
              <v-icon>mdi-bank</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
              <v-list-item-title v-text="room.number" />
            </v-list-item-content>
          </v-list-item>
        </v-list-item-group>
      </v-list>
    </v-card-text>
  </v-card>
</template>

<script>

export default {

  components: { },

  props: {
    rooms: {
      type: Array,
      required: true,
      default () {
        return []
      }
    }
  },

  data () {
    return {
      selectedRoomIndex: undefined,
      selectedRoom: null
    }
  },

  watch: {
    rooms () {
      this.selectedRoomIndex = 0
    },

    selectedRoomIndex () {
      if (this.selectedRoomIndex !== undefined) {
        this.selectedRoom = this.rooms[this.selectedRoomIndex]
        this.updateSelectedRoom()
      }
    }
  },

  methods: {
    updateSelectedRoom () {
      this.$emit('update-selected-room', this.selectedRoom)
    }
  }
}
</script>
