import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Eventts/`;

export default class EventsService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }
    add(taskType) {
        return axios.post(`${URL}Add`, taskType, { headers: authHeader() });
    }
    update(taskType) {
        return axios.post(`${URL}Update`, taskType, { headers: authHeader() });
    }
    changeActivity2(taskTypeId) {
        return axios.get(`${URL}ChangeActivity?id=${taskTypeId}`, { headers: authHeader() });
    }
    getAllLastEventsByNumber(taskNumber) {
        return axios.get(`${URL}GetAllLastEventsByNumber?number=${taskNumber}`, { headers: authHeader() });
    }
}
