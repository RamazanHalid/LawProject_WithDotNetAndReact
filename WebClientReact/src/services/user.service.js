
import axios from 'axios';
import { Global } from 'src/Global';
import authHeader from './auth-header';

const URL = `${Global.API_URL}Users/`;
export default class UserService {
  getAll() {
    return axios.get(`${URL}GetAllUserExceptAlreadyRecordedUsersInLicence`, { headers: authHeader() });
  }
  getAllUsersAsAdmin(firstName, lastName, cellPhone, isActive, email, pageNumber, pageSize) {
    return axios.post(`${URL}GetAllUsersAsAdmin?pageNumber=${pageNumber}&pageSize=${pageSize}`, { firstName, lastName, cellPhone, isActive, email,
      headers: authHeader() });
  }
  getByUserIdAsAdmin(id) {
    return axios.get(`${URL}GetByUserIdAsAdmin?id=${id}`, { headers: authHeader() });
  }
}
