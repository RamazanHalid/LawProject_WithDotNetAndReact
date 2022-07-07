import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Notifications/`;

export default class NotificationsService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    makeAllItRead() {
        return axios.get(`${URL}MakeAllItRead`, { headers: authHeader() });
    }
    getCount() {
        return axios.get(`${URL}GetCount`, { headers: authHeader() });
    }
    deleteAll() {
        return axios.get(`${URL}DeleteAll`, { headers: authHeader() });
    }
    delete(id) {
        return axios.get(`${URL}Delete?id=` + id , { headers: authHeader() });
    }
}
