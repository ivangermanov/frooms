import { IUser } from 'types'

export const state = () => ({
  info: {
    email: undefined,
    family_name: undefined,
    given_name: undefined,
    name: undefined,
    picture: undefined,
    preferred_username: undefined,
    profile: undefined,
    role: undefined,
    sub: undefined,
    updated_at: undefined
  } as IUser
})

export const mutations = {
  setUser (state: any, payload: IUser) {
    state.info = { ...state.info, ...payload }
  }
}