import Vue from 'vue';
import Vuex from 'vuex';

Vue.use(Vuex);

const state = {
    categorys: null
}

const mutations = {
    categorys(state, c) {
        state.categorys = c;
    }
}


export default new Vuex.Store({
    state,
    mutations
})
