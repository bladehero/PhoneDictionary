const axios = require('axios')

export default {
  async getAllCities () {
    var cities = await axios.get(`${process.env.VUE_APP_API}/Cities`)
    return cities
  }
}
