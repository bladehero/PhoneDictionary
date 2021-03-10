import api from '../../api/users'

const state = () => ({
  userName: null,
  tags: [],
  contacts: []
})

const getters = {
  userName: state => state.userName,
  tags: state => state.tags,
  contacts: state => state.contacts
}

const actions = {
  getUserById: async ({ commit }, userId) => {
    var response = await api.getUserById(userId)
    commit('setUser', response.data)
  },
  resetPage: ({ commit }) => {
    commit('setUser')
  }
}

const mutations = {
  setUser (state, user) {
    state.userName = user.userName
    state.tags = user.tags
    state.contacts = user.contacts
  },
  clearUser(state){
    state.userName = null
    state.tags = []
    state.contacts = []
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
