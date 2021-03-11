const axios = require('axios')

export default {
  async getAllContactTypes () {
    var contactTypes = await axios.get(
      `${process.env.VUE_APP_API}/ContactTypes`
    )
    return contactTypes
  }
}
