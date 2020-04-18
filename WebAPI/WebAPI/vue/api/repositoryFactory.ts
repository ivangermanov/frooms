import roomRepository from './roomRepository'
import authRepository from './authRepository'
import campusRepository from './campusRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository,
  campus: campusRepository
}

export const RepositoryFactory = repositories
