<template>
  <div class="text-center">
    <v-dialog v-model="loading" hide-overlay persistent width="300">
      <v-card color="primary" dark>
        <v-card-text>
          {{ text }}
          <v-progress-linear indeterminate color="white" class="mb-0" />
        </v-card-text>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
export default {
  props: {
    loading: {
      type: Boolean,
      required: true,
      default: true
    },
    text: {
      type: String,
      required: false,
      default: 'Loading data...'
    }
  }
}
</script>
