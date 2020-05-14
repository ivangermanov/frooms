export default function ({ store, redirect }) {
  console.log('Triggered admin middleware')
  if (store.state.user.info.role !== undefined) {
    if (!store.state.user.info.role.includes('admin')) {
      console.log('Redirected by admin middleware not since user does not have admin role')
      return redirect('/')
    }
  } else {
    console.log('Redirected by admin middleware since user info could not be retrieved')
    return redirect('/')
  }
}
