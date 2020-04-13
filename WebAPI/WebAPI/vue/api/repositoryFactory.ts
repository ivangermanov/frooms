import roomRepository from './roomRepository'
import authRepository from './authRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository
}

export const RepositoryFactory = repositories
