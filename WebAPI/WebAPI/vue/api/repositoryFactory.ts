import roomRepository from './roomRepository'
import campusRepository from './campusRepository'

const repositories = {
  room: roomRepository,
  campus: campusRepository
  // Other repositories
}

export const RepositoryFactory = repositories
