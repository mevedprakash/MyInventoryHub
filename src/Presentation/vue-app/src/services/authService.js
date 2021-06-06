import axios from 'axios'
import {apiUrl} from '@/config';
export default {
    forgotPassword(email) {
        return axios.post(apiUrl+"/auth/password/forgot", { email });
    },

    async login(email, password) {
        let response=await axios.post(apiUrl+"api/Auth/login", { email, password });
        let user= response.data;
        localStorage.setItem("user",JSON.stringify(user));
        return user;
    },

    logout() {
        return axios.get(apiUrl+"/auth/logout");
    },

    register(payload) {
        return axios.post(apiUrl+"/auth/register", payload);
    }
};