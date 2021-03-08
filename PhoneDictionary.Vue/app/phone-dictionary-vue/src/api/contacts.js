const axios = require('axios')

export default {
  async getContacts (page, size, contactType) {
    var contacts = await axios.get(`${process.env.VUE_APP_API}/Contacts?Page=${page}&Size=${size}&ContactType=${contactType}`)
    return contacts
  }
}
