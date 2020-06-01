import { RepositoryFactory } from '@/api/repositoryFactory'
const UserRepository = RepositoryFactory.user

export default async function ({ store }) {
  if (store.state.user.info.email === undefined) {
    const { data: info } = await UserRepository.getUserInfo()
    const { data: roles } = await UserRepository.getUserRoles()
    info.role = roles

    store.commit('user/setUser', info)
  }
}
