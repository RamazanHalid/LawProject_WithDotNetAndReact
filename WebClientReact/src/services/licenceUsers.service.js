
import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}LicenceUsers/`;

export default class LicenceUsersService {
    getAll() {
        return axios.get(`${URL}GetAll`, { headers: authHeader() });
    }
    usersForIgnore() {
        return axios.get(`${URL}UsersForIgnore`, { headers: authHeader() });
    }
    GetAllByUserId(UserId) {
        return axios.get(`${URL}GetAllAcceptedByUserId?userId=${UserId}`)
    }
    GetAllByUserIdWithNotAccept() {
        return axios.get(`${URL}GetAllAuthUser`, { headers: authHeader() })
    }
    add(userId) {
        return axios.post(`${URL}Add`, { userId }, { headers: authHeader() });
    }
    ChangeAcceptence(id) {
        return axios.get(`${URL}ChangeAcceptence?id=${id}`)
    }
    getById(UserId) {
        return axios.get(`${URL}GetById?id=${UserId}`, { headers: authHeader() })
    }
    getAllUserRecordToLicence(pageNumber, pageSize, licenceId) {
        return axios.get(`${URL}GetAllUserRecordToLicence?pageNumber=${pageNumber}&pageSize=${pageSize}&licenceId=${licenceId}`, {
            headers: authHeader()
        });
    }
}
