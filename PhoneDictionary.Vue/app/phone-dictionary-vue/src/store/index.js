import Vue from 'vue'
import Vuex from 'vuex'
import cities from './modules/cities'
import contactTypes from './modules/contactTypes'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    cities,
    contactTypes
  },
  state: {},
  mutations: {},
  actions: {}
})
