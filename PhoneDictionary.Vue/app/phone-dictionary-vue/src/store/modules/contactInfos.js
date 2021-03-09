import api from '../../api/contactInfos'

const state = () => ({
  info: null
})

const getters = {
  infoUserName: state => state.info?.userName,
  infoCountry: state => state.info?.country,
  infoCity: state => state.info?.city,
  infoProvider: state => state.info?.provider,
  infoContact: state => state.info?.contact
}

const actions = {
  getContactInfo: async ({ commit }, contactInfoId) => {
    var response = await api.getContactInfo(contactInfoId)
    commit('setContactInfo', response.data)
  }
}

const mutations = {
  setContactInfo (state, info) {
    state.info = info
  },
  clearContactInfo (state) {
    state.info = null
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
