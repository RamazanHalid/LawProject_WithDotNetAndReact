import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}TaskStatuses/`;

export default class TaskStatusesService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    delete(id) {
        return axios.get(`${URL}Delete?id=${id}`, { headers: authHeader() });
    }
    add(tasks) {
        return axios.post(`${URL}Add`, tasks, { headers: authHeader() });
    }
    update(tasks) {
        return axios.post(`${URL}Update`, tasks, { headers: authHeader() });
    }
}
