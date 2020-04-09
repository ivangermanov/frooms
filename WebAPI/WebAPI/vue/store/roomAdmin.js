export const state = () => ({
  editMode: false,
  deleteMode: false
})

export const mutations = {
  setEditMode (state, flag) {
    state.editMode = flag
  },
  setDeleteMode (state, flag) {
    state.deleteMode = flag
  }
}
