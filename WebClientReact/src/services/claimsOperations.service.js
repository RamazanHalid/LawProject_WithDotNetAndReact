
import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}UserOperationClaims/`;

export default class ClaimsOperationsService {
    getAll(userId) {
        return axios.get(`${URL}GetAll?userId=` + userId ,{ headers: authHeader() });
    }
    change(userId, userClaimList) {
        return axios.post(`${URL}AddAsList?userId=`+ userId, userClaimList, { headers: authHeader() });
    }
}
