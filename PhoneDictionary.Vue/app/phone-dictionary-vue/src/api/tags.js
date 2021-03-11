const axios = require('axios')

export default {
  async createTag (userId, tag, color) {
    const response = await axios.post(`${process.env.VUE_APP_API}/Tags`, {
      userId,
      tag,
      color
    })
    return response.data
  }
}
