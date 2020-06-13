<template>
  <blocked-wrapper>
    <portal to="modals">
      <reserve-modal @close="$router.back()" />
    </portal>
  </blocked-wrapper>
</template>

<script>
import ReserveModal from '~/components/reserve-room/ReserveModal.vue'
import BlockedWrapper from '~/components/blocked-flow/BlockedWrapper.vue'

export default {
  components: { ReserveModal, BlockedWrapper }
}
</script>
