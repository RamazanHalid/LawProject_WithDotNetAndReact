import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}ProcessTypes/`;

export default class ProcessTypeService {
    // eslint-disable-next-line class-methods-use-this
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    // eslint-disable-next-line class-methods-use-this
    getAllActive() {
        return axios.get(`${URL}GetAllActive`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }

    // eslint-disable-next-line class-methods-use-this
    add(processType) {
        return axios.post(`${URL}Add`, processType, { headers: authHeader() });
    }
    update(processType) {
        return axios.post(`${URL}Update`, processType, { headers: authHeader() });
    }
    changeActivity2(processTypeId) {
        return axios.get(`${URL}ChangeActivity?id=${processTypeId}`, { headers: authHeader() });
    }
}
