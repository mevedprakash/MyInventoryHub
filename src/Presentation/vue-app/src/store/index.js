import { createStore } from 'vuex'
import product from '@/store/product'
import brand from '@/store/brand'
import apiService from "@/services/api";
// Create a new store instance.
const store = createStore({
    state() {
        return {
            count: 0,
            units: [],
            paymentTypes:[],
            store:null
        }
    },
    modules: {
        product,
        brand
    },
    getters: {
        units(state) {
            return state.units;
        },
        paymentTypes(state){
            return state.paymentTypes
        },
        store(state){
            return state.store;
        }
    },
    mutations: {
        increment(state) {
            state.count++
        },
        getUnits(state, units) {
            state.units = units;
        },
        PaymentTypes(state, types) {
            state.paymentTypes = types;
        },
        store(state, store) {
            state.store = store;
        }

    },
    actions: {
        increment(context) {
            context.commit('increment')
        },
        async getUnits(context) {
            let units = await apiService.getUnits();
            context.commit("getUnits", units);
        },
        async getPaymentTypes(context) {
            let types = await apiService.getPaymentTypes();
            context.commit("PaymentTypes", types);
        },
        async getStore(context) {
            let store = await apiService.getStore();
            context.commit("store", store);
        }    
    }

})
export default store;