import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}SmsOrders/`;

export default class SmsOrdersService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    buyTheSms(id) {
        return axios.get(`${URL}BuyTheSms?id=${id}`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    delete(id) {
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    add(roleTypes) {
        return axios.post(`${URL}Add`, roleTypes, { headers: authHeader() });
    }
    update(roleTypes) {
        return axios.post(`${URL}Update`, roleTypes, { headers: authHeader() });
    }
}
