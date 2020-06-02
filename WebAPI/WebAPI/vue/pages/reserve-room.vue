<template>
  <div>
    <portal to="modals">
      <reserve-modal @close="$router.back()" />
    </portal>
  </div>
</template>

<script>
import ReserveModal from '~/components/reserve-room/ReserveModal.vue'

export default {
  components: { ReserveModal }
}
</script>
