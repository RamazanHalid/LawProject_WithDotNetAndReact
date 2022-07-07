import axios from 'axios';
import { Global } from 'src/Global';
import authHeader from './auth-header';

const URL = `${Global.API_URL}UserProfileAvatar/`;
export default class UserProfileAvatarService {
    getAll() {
        return axios.get(`${URL}GetAll`, {headers: authHeader()});
    }
}