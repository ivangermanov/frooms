import roomRepository from './roomRepository'
import authRepository from './authRepository'
import campusRepository from './campusRepository'
import buildingRepository from './buildingRepository'
import floorRepository from './floorRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository,
  campus: campusRepository,
  building: buildingRepository,
  floor: floorRepository
}

export const RepositoryFactory = repositories
