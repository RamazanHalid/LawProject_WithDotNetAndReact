
import axios from 'axios';
import { Global } from '../Global';
import authHeader from './auth-header';

const URL = `${Global.API_URL}CourtOfficeTypes/`;

export default class CourtOfficeTypesService {
  // eslint-disable-next-line class-methods-use-this
  getAll() {
    return axios.get(`${URL}GetAll`, { headers: authHeader() });
  }
}
