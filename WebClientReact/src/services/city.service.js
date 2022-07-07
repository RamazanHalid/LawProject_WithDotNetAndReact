import axios from 'axios';
import {Global} from "../Global";

const URL = `${Global.API_URL}Cities/`;

export default class CityService {
  getAll(countryId) {
    return axios.get(`${URL}GetAll?countryId=${countryId}`); 
  }
}
