import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}ChatSupports/`;

export default class ChatSupportService {
    getAllMessegaAsUser() {
        return axios.get(`${URL}GetAllMessegaAsUser`, { headers: authHeader() });
    }
    getAllMessegaAsAdmin(userId, licenceId) {
        return axios.get(`${URL}GetAllMessegaAsAdmin?userId=${userId}&licenceId=${licenceId}`, { headers: authHeader() });
    }
    addMessegaAsUser(message) {
        return axios.post(`${URL}AddMessegaAsUser`, message, { headers: authHeader() });
    }
    addMessegaAsAdmin(message) {
        return axios.post(`${URL}AddMessegaAsAdmin`, message, { headers: authHeader() });
    }
    makeItReadAsUser() {
        return axios.get(`${URL}MakeItReadAsUser`, { headers: authHeader() });
    }
    makeItReadAsAdmin(userId, licenceId) {
        return axios.get(`${URL}MakeItReadAsAdmin?userId=${userId}&licenceId=${licenceId}`, { headers: authHeader() });
    }
    listUsersToSideBar() {
        return axios.get(`${URL}ListUsersToSideBar`, { headers: authHeader() });
    }
}
