import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}TransactionActivitySubTypes/`;

export default class AccountActivityService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getAllByTransactionActivityId(id) {
        return axios.get(`${URL}GetAllByTransactionActivityTypeId?id=${id}`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    add(accountActivity) {
        return axios.post(`${URL}Add`, accountActivity, { headers: authHeader() });
    }
    delete(id) {
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    update(accountActivity) {
        return axios.post(`${URL}Update`, accountActivity, { headers: authHeader() });
    }
    changeActivity2(accountActivityId) {
        return axios.get(`${URL}ChangeActivity?id=${accountActivityId}`, { headers: authHeader() });
    }
}
