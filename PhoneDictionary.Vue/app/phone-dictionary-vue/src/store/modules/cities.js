import api from '../../api/cities'

const state = () => ({
  cities: []
})

const getters = {
  cities: state => state.cities
}

const actions = {
  getAllCities: async ({ commit }) => {
    var response = await api.getAllCities()
    commit('setCities', response.data.cities)
  }
}

const mutations = {
  setCities (state, cities) {
    state.cities = cities.map(x => {
      return { text: x, value: x }
    })
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
