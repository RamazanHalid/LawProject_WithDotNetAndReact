import axios from 'axios';
import { Global } from '../Global';

const API_URL = `${Global.API_URL}Auth/`;
export default class AuthService {
  // eslint-disable-next-line class-methods-use-this
  login(CellPhone, Password) {
    return axios.post(`${API_URL}login`, {
      CellPhone,
      Password
    });
  }

  // eslint-disable-next-line class-methods-use-this
  loginWithLicenceId(cellPhone, password, licenceId) {
    return axios.post(`${API_URL}login?licenceId=${licenceId}`, {
      cellPhone,
      password,
      licenceId
    });
  }

  // eslint-disable-next-line class-methods-use-this
  logout() {
    localStorage.removeItem('token');
    localStorage.removeItem('userClaims');
    localStorage.removeItem('USER');
    localStorage.removeItem('usr');
  }

  // eslint-disable-next-line class-methods-use-this
  register(cellPhone, password, firstName, lastName,email, title, cityId) {
    return axios.post(`${API_URL}register`, {
      cellPhone,
      password,
      firstName,
      lastName,
      email,
      title,
      cityId
    });
  }

  // eslint-disable-next-line class-methods-use-this
  approvingUser(cellPhone, smsCode) {
    return axios.post(`${API_URL}approvingUser`, {
      cellPhone,
      smsCode
    });
  }

  // eslint-disable-next-line class-methods-use-this
  ForgetPassword(cellPhone) {
    return axios.post(`${API_URL}ForgetPassword?cellPhone=${cellPhone}`, {
      cellPhone
    });
  }

  // eslint-disable-next-line class-methods-use-this
  UpdateUserPassword(cellPhone, smsCode, newPassword) {
    return axios.post(`${API_URL}UpdateUserPassword`, {
      cellPhone,
      smsCode,
      newPassword
    });
  }

  // eslint-disable-next-line class-methods-use-this
  getCurrentUser() {
    return JSON.parse(localStorage.getItem('token'));
  }

  // eslint-disable-next-line class-methods-use-this
  IsAuth() {
    if (localStorage.getItem('token')) {
      return true;
    }
    return false;
  }

  // eslint-disable-next-line class-methods-use-this
  DoesHaveMandatoryClaim(claim) {
    const claims = [...JSON.parse(localStorage.getItem('userClaims'))];
    if (claims.includes(claim)) {
      return true;
    }
    return false;
  }
}

