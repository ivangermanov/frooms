export const state = () => ({
  saved: true,
  editMode: false
})

export const mutations = {
  setSaved (state, flag) {
    state.saved = flag
  },
  setEditMode (state, flag) {
    state.editMode = flag
  }
}
