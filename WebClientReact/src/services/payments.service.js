import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Payments/`;

export default class PaymentsService {
    makePayment(id) {
        return axios.post(`${URL}MakePayment`, id, {headers: authHeader()});
    }
}
