
import axios from 'axios';
import {Global} from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}FilesHelper/`;

export default class FilesHelperService {
    addFileForCaseDocuments(myFile) {
        const formData = new FormData()
        formData.append("myFile", myFile)
        return axios.post(`${URL}AddFileForCaseDocuments`, formData,{ headers: authHeader() })
    }
}
