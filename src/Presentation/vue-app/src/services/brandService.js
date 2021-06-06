import axios from 'axios'
import {apiUrl} from '@/config';
export default {  
    async getBrands() {
        let response=await axios.get(apiUrl+"api/Common/brands");
        return response.data;
    },
    async addBrand(brand) {
        let response=await axios.post(apiUrl+"api/Common/brand/add",brand);
        return response.data;
    }
};