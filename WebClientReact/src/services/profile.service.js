import axios from 'axios';
import { Global } from "../Global";
import authHeader from "./auth-header";

const URL = `${Global.API_URL}Auth/`;

export default class ProfileService {
    getUserInfo() {
        return axios.get(`${URL}GetUserInfo`, { headers: authHeader() });
    }
    updateUserProfile(user) {
        return axios.post(`${URL}UpdateUserProfile`, user, { headers: authHeader() });
    }
}
