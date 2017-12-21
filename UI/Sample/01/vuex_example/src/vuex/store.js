import Vue from 'vue'
import Vuex from 'vuex'

import * as actions from './actions'
import * as getters from './getters'

Vue.use(Vuex)

const state = {
  count: 1
}

const mutations = {
  add (state) {
    state.count += 1
  },
  reduce (state) {
    state.count -= 1
  }
}

export default new Vuex.Store({
  actions,
  getters,
  state,
  mutations
})
