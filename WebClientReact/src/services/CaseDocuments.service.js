import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}CasesDocuments/`;

export default class CaseDocumentsService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    add(cases) {
        return axios.post(`${URL}Add`, cases, { headers: authHeader() });
    }
    update(cases) {
        return axios.post(`${URL}Update`, cases, { headers: authHeader() });
    }
}
