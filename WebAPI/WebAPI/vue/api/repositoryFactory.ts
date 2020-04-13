import roomRepository from './roomRepository'
import authRepository from './authRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository
  // Other repositories
}

export const RepositoryFactory = repositories
