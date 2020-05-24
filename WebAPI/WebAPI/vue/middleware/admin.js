export default function ({ store, redirect }) {
  console.log('Triggered admin middleware')
  if (!store.getters['user/isAdmin']) {
    console.log('Redirected by admin middleware not since user does not have admin role')
    return redirect('/')
  }
}
