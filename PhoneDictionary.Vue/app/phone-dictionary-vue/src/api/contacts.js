const axios = require('axios')

export default {
  async getContacts (page, size, contactTypes, cities, search) {
    let url = `${process.env.VUE_APP_API}/Contacts?Page=${page}&Size=${size}`

    if (contactTypes && contactTypes.length) {
      url += `&${contactTypes.map(x => `ContactTypes=${x}`).join('&')}`
    }

    if (cities && cities.length) {
      url += `&${cities.map(x => `Cities=${x}`).join('&')}`
    }

    if (search) {
      url += `&Search=${search}`
    }

    var contacts = await axios.get(encodeURI(url))
    return contacts
  }
}
