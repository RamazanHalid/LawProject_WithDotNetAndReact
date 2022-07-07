import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Casees/`;

export default class CasesService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    delete(id) {
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    add(cases) {
        return axios.post(`${URL}Add`, cases, { headers: authHeader() });
    }
    update(cases) {
        return axios.post(`${URL}Update`, cases, { headers: authHeader() });
    }
    changeActivity2(casesId, caseStatusId) {
        return axios.get(`${URL}ChangeStatus?id=${casesId}&caseStatusId=${caseStatusId}`, { headers: authHeader() });
    }
    getAllByCustomerId(id) {
        return axios.get(`${URL}GetAllByCustomerId?customerId=${id}`, { headers: authHeader() });
    }
}
