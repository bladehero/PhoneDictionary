const axios = require('axios')

export default {
  async getContactInfo (сontactInfoId) {
    const info = await axios.get(`${process.env.VUE_APP_API}/ContactInfos?ContactInfoId=${сontactInfoId}`)
    return info
  }
}
