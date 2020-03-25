import axios from 'axios'

const baseDomain = 'https://i380810core.venus.fhict.nl/'
const baseURL = `${baseDomain}/api`

export default axios.create({ baseURL })
