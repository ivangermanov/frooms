import roomRepository from './roomRepository'
import authRepository from './authRepository'
import campusRepository from './campusRepository'
import buildingRepository from './buildingRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository,
  campus: campusRepository,
  building: buildingRepository
}

export const RepositoryFactory = repositories
