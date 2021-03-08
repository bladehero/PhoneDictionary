import api from '../../api/contactTypes'

const state = () => ({
  contactTypes: []
})

const getters = {
  contactTypes: state => state.contactTypes
}

const actions = {
  getAllContactTypes: async ({ commit }) => {
    var response = await api.getAllContactTypes()
    commit('setContactTypes', response.data)
  }
}

const mutations = {
  setContactTypes (state, contactTypes) {
    state.contactTypes = contactTypes.map(x => {
      return { text: x.text, value: x.value }
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
