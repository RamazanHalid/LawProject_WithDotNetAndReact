import axios from 'axios';
import {Global} from "../Global";

const URL = `${Global.API_URL}Countries/`;

export default class CountryService {
  // eslint-disable-next-line class-methods-use-this
  getAll() {
    return axios.get(`${URL}GetAll`);
  }
}
