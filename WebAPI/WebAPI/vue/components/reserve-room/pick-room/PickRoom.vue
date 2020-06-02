<template>
  <v-card>
    <v-card-title class="headline">
      Pick Room
    </v-card-title>
    <v-card-text>
      <v-row>
        <v-col v-if="false" class="col">
          <div style="height: 350px">
            <floor-map />
          </div>
        </v-col>
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
import FloorMap from '@/components/floor-map/FloorMap.vue'

export default {
  components: { FloorMap, BaseDropDownSelector },
  props: {
    initialFloor: {
      required: false,
      type: String,
      default: ''
    },
    initialRoom: {
      required: false,
      type: String,
      default: ''
    },
    selectedFloor: {
      type: Object,
      default () {
        return null
      }
    },
    selectedRoom: {
      type: Object,
      default () {
        return null
      }
    },
    rooms: {
      type: Array,
      required: true
    },
    floors: {
      type: Array,
      required: true
    }
  },
  data () {
    return {
      selectedRoomIndex: undefined,
      currentRoom: null,
      selectedFloorNumber: ''
    }
  },
  computed: {
    floorNumbers () {
      return this.floors.map(f => f.number)
    }
  },
  watch: {
    initialFloor: {
      handler (value) {
        this.selectedFloorNumber = value
      },
      immediate: true
    },
    floors () {
      this.updateSelectedFloor()
    },
    rooms () {
      this.selectedRoomIndex = undefined
    },
    selectedRoomIndex () {
      if (this.selectedRoomIndex !== undefined) {
        this.currentRoom = this.rooms[this.selectedRoomIndex]
        this.updateSelectedRoom()
      }
    }
  },
  methods: {
    updateSelectedRoom () {
      this.$emit('update-selected-room', this.currentRoom)
    },
    updateSelectedFloor () {
      const selected = this.floors.filter(f => f.number === this.selectedFloorNumber)[0]
      this.$emit('update:selected-floor', selected)
      this.$emit('fetch-rooms')
    }
  }
}
</script>
