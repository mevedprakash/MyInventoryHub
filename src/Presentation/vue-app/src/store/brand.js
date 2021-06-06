
import brandService from "@/services/brandService";
const brand = {
    state() {
        return {
            brands: []
        }
    },
    getters: {     
        brands(state) {
            return (filter)=>{
                if(!filter)
                return state.brands;
                let filteredData = [...state.brands];
                if (filter.name)
                    filteredData = filteredData.filter(x => x.name.toLowerCase().includes(filter.name.toLowerCase()));
                return filteredData;
            }
        },
        totalBrand(state) {
            return state.brands.length;
        }
    },
    mutations: {       
        getBrands(state, brands) {
            state.brands = brands;
        }
    },
    actions: {       
        async getBrands(context) {
            let brands = await brandService.getBrands();
            context.commit("getBrands", brands);
        },
        async saveBrand(context, brand) {
            await brandService.addBrand(brand);
            context.dispatch("getBrands");
        }        
    }

}
export default brand;