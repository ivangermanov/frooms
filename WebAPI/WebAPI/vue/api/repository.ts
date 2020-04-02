import axios from 'axios'
import toastr from 'toastr'

let baseDomain = ''

if (process.env.NODE_ENV === 'development') {
  baseDomain = 'https://localhost:44338'
}

console.log(baseDomain)

const baseUrl = `${baseDomain}/api`

const globalAxios = axios.create({ baseURL: baseUrl })

globalAxios.interceptors.response.use((response) => {
  if (response.config.method !== 'get') {
    toastr.success('Your request was successfully processed!')
  }
  return response
}, (error) => {
  const config = error.config
  if (config.method !== 'get') {
    toastr.error('There was an error processing your request. Please try again.')
  }
  return Promise.reject(error)
})

export default globalAxios
