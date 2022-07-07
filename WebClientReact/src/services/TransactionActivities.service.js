import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}TransactionActivities/`;

export default class TransactionActivitiesService {
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
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
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
    totalBalance() {
        return axios.get(`${URL}TotalBalance`, { headers: authHeader() });
    }
    totalExpense() {
        return axios.get(`${URL}TotalExpense`, { headers: authHeader() });
    }
    totalIncome() {
        return axios.get(`${URL}TotalIncome`, { headers: authHeader() });
    }
}
