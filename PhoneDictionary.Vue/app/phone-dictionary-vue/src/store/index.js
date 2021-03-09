import Vue from 'vue'
import Vuex from 'vuex'
import cities from './modules/cities'
import contactTypes from './modules/contactTypes'
import contacts from './modules/contacts'
import contactInfos from './modules/contactInfos'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    cities,
    contactTypes,
    contacts,
    contactInfos
  },
  state: {},
  mutations: {},
  actions: {}
})
