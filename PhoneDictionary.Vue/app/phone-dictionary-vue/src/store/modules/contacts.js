import api from '../../api/contacts'

const state = () => ({
  contacts: [],
  pages: 0,
  records: 0,
  page: 1,
  size: 5,
  params: {
    search: null,
    contactTypes: [],
    cities: []
  }
})

const getters = {
  contacts: state => state.contacts.slice(0, state.size),
  pages: state => state.pages,
  records: state => state.records,
  page: state => state.page,
  size: state => state.size
}

const actions = {
  getContacts: async ({ commit, getters, state }) => {
    var response = await api.getContacts(
      getters.page - 1,
      getters.size,
      state.params.contactTypes,
      state.params.cities,
      state.params.search
    )
    commit('setPages', response.data.pages)
    commit('setRecords', response.data.records)
    commit('setContacts', response.data.contacts)
  },
  resetPage: ({ commit }) => {
    commit('setPage', 1)
  }
}

const mutations = {
  setContacts (state, contacts) {
    state.contacts = contacts
  },
  setPages (state, pages) {
    state.pages = pages
  },
  setRecords (state, records) {
    state.records = records
  },
  setPage (state, page) {
    state.page = page
  },
  setSize (state, size) {
    state.size = size
  },
  setSearchParams (state, { search, contactTypes, cities }) {
    if (search !== undefined) {
      state.params.search = search
    }
    state.params.contactTypes = contactTypes || state.params.contactTypes
    state.params.cities = cities || state.params.cities
  },
  clearSearchParams (state) {
    state.params = {
      search: null,
      contactTypes: [],
      cities: []
    }
  }
}

export default {
  namespaced: true,
  state,
  getters,
  actions,
  mutations
}
