
import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}OperationClaimGroups/`;

export default class OperationClaimGroupsService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
}
