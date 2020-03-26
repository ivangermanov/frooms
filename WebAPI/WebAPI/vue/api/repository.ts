import axios from 'axios'

let baseDomain = ''

if (process.env.NODE_ENV === 'development') {
  baseDomain = 'https://localhost:44338'
}

console.log(baseDomain)

const baseUrl = `${baseDomain}/api`

export default axios.create({ baseURL: baseUrl })
