import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}SmsTemplates/`;

export default class SmsTemplateService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    getCount() {
        return axios.get(`${URL}GetCount`, { headers: authHeader() });
    }
    add(reminders) {
        return axios.post(`${URL}Add`, reminders, { headers: authHeader() });
    }
    update(reminders) {
        return axios.post(`${URL}Update`, reminders, { headers: authHeader() });
    }
    delete(remindersId) {
        return axios.get(`${URL}Delete?id=${remindersId}`, { headers: authHeader() });
    }
}
