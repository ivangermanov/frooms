import roomRepository from './roomRepository'
import authRepository from './authRepository'
import campusRepository from './campusRepository'
import buildingRepository from './buildingRepository'
import floorRepository from './floorRepository'
import fontysApiRepository from './fontysApiRepository'

const repositories = {
  room: roomRepository,
  auth: authRepository,
  campus: campusRepository,
  building: buildingRepository,
  floor: floorRepository,
  fontysApi: fontysApiRepository
}

export const RepositoryFactory = repositories
