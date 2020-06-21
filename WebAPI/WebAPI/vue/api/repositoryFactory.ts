import roomRepository from './roomRepository'
import userRepository from './userRepository'
import campusRepository from './campusRepository'
import reservationRepository from './reservationRepository'
import buildingRepository from './buildingRepository'
import floorRepository from './floorRepository'
import fontysApiRepository from './fontysApiRepository'
import chartRepository from './chartRepository'
import adminUserRepository from './admin/userRepository'
import adminReservationRepository from './admin/reservationRepository'
import adminChartRepository from './admin/chartRepository'
import adminRoomRepository from './admin/roomRepository'

const repositories = {
  room: roomRepository,
  campus: campusRepository,
  user: userRepository,
  reservation: reservationRepository,
  building: buildingRepository,
  floor: floorRepository,
  fontysApi: fontysApiRepository,
  chart: chartRepository,
  adminUser: adminUserRepository,
  adminReservation: adminReservationRepository,
  adminChart: adminChartRepository,
  roomAdmin: adminRoomRepository
}

export const RepositoryFactory = repositories
