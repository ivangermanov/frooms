<template>
  <v-card>
    <v-card-title class="headline">
      Pick Room
    </v-card-title>
    <v-card-text>
      <v-row>
        <v-col class="col">
          <base-drop-down-selector
            :items="floorNumbers"
            :selection.sync="selectedFloorNumber"
            label="Select a floor"
            icon="mdi-map-marker"
          />
          <v-list rounded class="overflow-y-auto">
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
        </v-col>
      </v-row>
    </v-card-text>
  </v-card>
</template>

<script>
import BaseDropDownSelector from '@/components/base/BaseDropdownSelector.vue'

export default {
  components: { BaseDropDownSelector },
  props: {
    initialFloorNumber: {
      required: false,
      type: String,
      default: ''
    },
    initialRoomNumber: {
      required: false,
      type: String,
      default: ''
    },
    selectedFloor: {
      type: Object,
      default: null
    },
    selectedRoom: {
      type: Object,
      default: null
    },
    floors: {
      type: Array,
      required: true
    },
    rooms: {
      type: Array,
      required: true
    }
  },
  data () {
    return {
      selectedFloorNumber: '',
      selectedRoomNumber: '',
      selectedRoomIndex: ''
    }
  },
  computed: {
    floorNumbers () {
      return this.floors.map(f => f.number)
    },
    roomNumbers () {
      return this.rooms.map(r => r.number)
    },
    selectedFloorTemp () {
      return this.floors.find(f => f.number === this.selectedFloorNumber)
    },
    selectedRoomTemp () {
      return this.rooms.find(r => r.number === this.selectedRoomNumber)
    }
  },
  watch: {
    initialFloorNumber: {
      handler (value) {
        this.selectedFloorNumber = value
      },
      immediate: true
    },
    initialRoomNumber: {
      handler (value) {
        this.selectedRoomNumber = value
      },
      immediate: true
    },
    rooms (value) {
      if (value) {
        this.selectedRoomIndex = value.findIndex(r => r.number === this.selectedRoomNumber)
      }
    },
    selectedFloorTemp () {
      this.updateSelectedFloor()
    },
    selectedRoomTemp () {
      this.updateSelectedRoom()
    },
    selectedRoomIndex (value) {
      this.selectedRoomNumber = this.rooms[value]?.number
    }
  },
  methods: {
    updateSelectedRoom () {
      this.$emit('update:selected-room', this.selectedRoomTemp)
    },
    updateSelectedFloor () {
      this.$emit('update:selected-floor', this.selectedFloorTemp)
    }
  }
}
</script>
