<template>
  <div>
    <portal to="modals">
      <room-filter />
    </portal>
  </div>
</template>

<script>
import RoomFilter from '~/components/RoomFilter.vue'

export default {
  components: { RoomFilter }
}
</script>

<style>
</style>
