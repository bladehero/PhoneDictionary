const axios = require('axios')

export default {
  async getContactInfo (contactInfoId) {
    const info = await axios.get(`${process.env.VUE_APP_API}/ContactInfos?ContactInfoId=${contactInfoId}`)
    return info
  }
}
