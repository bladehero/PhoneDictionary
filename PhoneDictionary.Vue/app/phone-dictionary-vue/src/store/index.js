import Vue from 'vue'
import Vuex from 'vuex'
import cities from './modules/cities'
import contactTypes from './modules/contactTypes'
import contacts from './modules/contacts'
import contactInfos from './modules/contactInfos'
import users from './modules/users'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    cities,
    contactTypes,
    contacts,
    contactInfos,
    users
  },
  state: {},
  mutations: {},
  actions: {}
})
