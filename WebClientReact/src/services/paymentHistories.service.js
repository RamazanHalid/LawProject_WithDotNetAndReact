import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}PaymentHistories/`;

export default class PaymentHistoriesService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getAllAsAdmin(pageNumber, pageSize, licenceId) {
        return axios.get(`${URL}GetAllAsAdmin?pageNumber=${pageNumber}&pageSize=${pageSize}&licenceId=${licenceId}`, {
            headers: authHeader()
        });
    }
}
