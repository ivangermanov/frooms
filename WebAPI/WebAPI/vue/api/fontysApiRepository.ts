import Repository from './repository'

const resource = '/fontys'

export default {
  getLocationMapImage (campusName: string, buildingName: string, floorNumber: string) {
    return Repository.get(`${resource}/location/mapimage/${campusName}/${buildingName}/${floorNumber}`,
      { responseType: 'arraybuffer' })
      .then(response => 'data:image/png;base64,' + Buffer.from(response.data, 'binary').toString('base64'))
  }
}
