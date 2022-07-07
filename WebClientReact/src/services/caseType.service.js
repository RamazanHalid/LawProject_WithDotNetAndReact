import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}CaseTypes/`;

export default class CaseTypeService {
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
    add(caseType) {
        return axios.post(`${URL}Add`, caseType, { headers: authHeader() });
    }
    update(caseType) {
        return axios.post(`${URL}Update`, caseType, { headers: authHeader() });
    }
    changeActivity2(caseTypeId) {
        return axios.get(`${URL}ChangeActivity?id=${caseTypeId}`, { headers: authHeader() });
    }
}
