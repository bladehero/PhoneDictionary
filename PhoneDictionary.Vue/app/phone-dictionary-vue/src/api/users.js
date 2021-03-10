const axios = require('axios')

export default {
  async getUserById (userId) {
    const user = await axios.get(`${process.env.VUE_APP_API}/Users?UserId=${userId}`)
    return user
  }
}
