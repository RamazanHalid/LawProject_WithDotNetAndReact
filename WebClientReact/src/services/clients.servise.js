import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Customers/`;

export default class ClientsServise {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getAllByTransactionActivityId(id) {
        return axios.get(`${URL}GetAllByTransactionActivityTypeId?id=${id}`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    delete(id) {
        return axios.delete(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    add(transactionActivity) {
        return axios.post(`${URL}Add`, transactionActivity, { headers: authHeader() });
    }
    update(transactionActivity) {
        return axios.post(`${URL}Update`, transactionActivity, { headers: authHeader() });
    }
    changeActivity2(transactionActivityId) {
        return axios.get(`${URL}ChangeActivity?id=${transactionActivityId}`, { headers: authHeader() });
    }
}
