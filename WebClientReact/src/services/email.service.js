import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Emails/`;

export default class EmailService {
    sendEmailToCustomers(email) {
        return axios.post(`${URL}SendEmailToCustomers`, email, { headers: authHeader() });
    }
    sendEmailToMembers(email) {
        return axios.post(`${URL}SendEmailToMembers`, email, { headers: authHeader() });
    }
    sendEmail(email) {
        return axios.post(`${URL}SendEmail`, email,{ headers: authHeader() });
    }
}
