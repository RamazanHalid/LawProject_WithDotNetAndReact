import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}CaseStatuses/`;

export default class CaseStatusesService {
    // eslint-disable-next-line class-methods-use-this
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    // eslint-disable-next-line class-methods-use-this
    add(caseStatus) {
        return axios.post(`${URL}Add`, caseStatus, { headers: authHeader() });
    }
    update(caseStatus) {
        return axios.post(`${URL}Update`, caseStatus, { headers: authHeader() });
    }
    changeActivity2(caseStatusId) {
        return axios.get(`${URL}ChangeActivity?id=${caseStatusId}`, { headers: authHeader() });
    }
}
