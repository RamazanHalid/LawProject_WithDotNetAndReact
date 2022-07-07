import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}TransactionActivityTypes/`;

export default class TransactionActivityTypeService {
    // eslint-disable-next-line class-methods-use-this
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    getById(id) {
        return axios.get(`${URL}GetById?id=${id}`, { headers: authHeader() });
    }

    // eslint-disable-next-line class-methods-use-this
    add(accountActivity) {
        return axios.post(`${URL}Add`, accountActivity, { headers: authHeader() });
    }
    update(accountActivity) {
        return axios.post(`${URL}Update`, accountActivity, { headers: authHeader() });
    }
    changeActivity2(accountActivityId) {
        return axios.get(`${URL}ChangeActivity?id=${accountActivityId}`, { headers: authHeader() });
    }
}
