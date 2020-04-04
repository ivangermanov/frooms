export const state = () => ({
  saved: true
})

export const mutations = {
  setSaved (state, flag) {
    state.saved = flag
  }
}
