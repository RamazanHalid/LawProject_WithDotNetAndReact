import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}CourtOffices/`;

export default class CourtOfficesService {
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
    delete(id) {
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    // eslint-disable-next-line class-methods-use-this
    add(courtOffice) {
        return axios.post(`${URL}Add`, courtOffice, { headers: authHeader() });
    }
    update(courtOffice) {
        return axios.post(`${URL}Update`, courtOffice, { headers: authHeader() });
    }
    changeActivity2(courtOfficeId) {
        return axios.get(`${URL}ChangeActivity?id=${courtOfficeId}`, { headers: authHeader() });
    }
}
