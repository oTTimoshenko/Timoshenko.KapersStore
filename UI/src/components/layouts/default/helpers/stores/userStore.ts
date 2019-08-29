import axios from "axios";
import apiService from '@/components/layouts/default/helpers/services/apiService';
import constants from '@/components/layouts/default/helpers/constants/constants'

const state: any = {
  token: localStorage.getItem(constants.userToken) || '',
  status: '',
  user: JSON.parse(localStorage.getItem(constants.userInfo) as string) || {}
}

const getters = {
  isAuthenticated: (state: any) => !!state.token,
  authStatus: (state: any) => state.status
}

const actions = {
  ['AUTH_REQUEST']: ({commit, dispatch}, user) => {
    return new Promise((resolve, reject) => {
      debugger
      commit('AUTH_REQUEST')
      apiService.post('users', 'authenticate', user)
        .then(response => {
          
          const token = response.data.token;
          localStorage.setItem(constants.userToken, token);
          localStorage.setItem(constants.userInfo, JSON.stringify(response.data));
          axios.defaults.headers.common[constants.authorizationHeaderName] = token;
          commit('AUTH_SUCCESS', response.data);
          //dispatch('USER_REQUEST');
          resolve(response);
        })
        .catch(error => {
          commit('AUTH_ERROR', error);
          localStorage.removeItem(constants.userToken);
          localStorage.removeItem(JSON.stringify(constants.userInfo));
          reject(error);
        })
    })
  },
  ['AUTH_LOGOUT']: ({commit, dispatch}) => {
    return new Promise((resolve, reject) => {
      commit('AUTH_LOGOUT');
      localStorage.removeItem(constants.userToken);
      localStorage.removeItem(constants.userInfo);
      delete axios.defaults.headers.common[constants.authorizationHeaderName];
      resolve();
    })
  }
}

const mutations = {
  ['AUTH_REQUEST']: (state) => {
    state.status = 'loading';
  },
  ['AUTH_SUCCESS']: (state, userInfo) => {
    state.status = 'success';
    state.token = userInfo.token;
    state.user = userInfo;
  },
  ['AUTH_ERROR']: (state) => {
    state.status = 'error';
  },
  ['AUTH_LOGOUT']: (state) => {
    state.token = '';
    state.status = '';
  }
}

const userStore = {
  state,
  mutations,
  actions,
  getters
}

export default userStore;