import axios from 'axios'
import {apiUrl} from '@/config';
export default {  
    async getProducts() {
        let response=await axios.get(apiUrl+"api/Product/products");
        return response.data;
    },
    async getLowStockProducts() {
        let response=await axios.get(apiUrl+"api/Product/lowstock");
        return response.data;
    },
    async saveProduct(product) {
        let response=await axios.post(apiUrl+"api/Product/product/add",product);
        return response.data;
    },
    async getBestSellingProducts() {
        let response=await axios.get(apiUrl+"api/Product/bestselling");
        return response.data;
    },
    
    
};