import axios from 'axios'
import {apiUrl} from '@/config';
export default {
    async getOrders() {
        let response = await axios.get(apiUrl+"api/Order/orders");
        return response.data;
    },
    async getOrder(orderId) {
        let response = await axios.get(apiUrl+"api/Order/orderdetail/" + orderId);
        return response.data;
    }, 
    async saveOrder(order) {
        let response = await axios.post(apiUrl+"api/Order/order/add",order);
        return response.data;
    },
    async getProductSuppllies() {
        let response = await axios.get(apiUrl+"api/Supply/productsupply");
        return response.data;
    }
};