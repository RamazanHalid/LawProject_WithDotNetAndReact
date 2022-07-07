import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}CasesUpdateHistories/`;

export default class CaseUpdateHistoryService {
    getAllByCaseId(skipVal, takeVal,caseId) {
        return axios.get(`${URL}GetAllByCaseId?skipVal=${skipVal}&takeVal=${takeVal}&caseId=${caseId}`, { headers: authHeader() });
    }

}
