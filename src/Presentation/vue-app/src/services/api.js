import axios from 'axios'
import {apiUrl} from '@/config';
axios.interceptors.request.use(
    function (req) {
       let user=localStorage.getItem('user');
       console.log(req);
       if(user){
           let token=JSON.parse(user).accessToken;
           console.log(token);
           req.headers.Authorization =  "bearer "+token;
       }
       
       return req;
    },
    (err) => {
      return Promise.reject(err);
    }
);
export default {
    async getUnits() {
        let response = await axios.get(apiUrl + "api/Common/units");
        return response.data;
    },
    async getPaymentTypes() {
        let response = await axios.get(apiUrl + "api/Common/paymenttypes");
        return response.data;
    },
    async getStore() {
        let response = await axios.get(apiUrl + "api/Admin/store");
        return response.data;
    },
    async saveStore(store) {
        await axios.post(apiUrl + "api/Admin/store",store);
    }
};