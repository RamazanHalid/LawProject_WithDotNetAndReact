import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Sms/`;

export default class SmsService {
    sendSmsToCustomers(sms) {
        return axios.post(`${URL}SendSmsToCustomers`, sms, { headers: authHeader() });
    }
    sendSmsToMembers(sms) {
        return axios.post(`${URL}SendSmsToMembers`, sms, { headers: authHeader() });
    }
    sendSms(sms) {
        return axios.post(`${URL}SendSms`, sms,{ headers: authHeader() });
    }
}
