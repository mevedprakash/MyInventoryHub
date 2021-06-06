
import productService from "@/services/productService";
const product = {
    state() {
        return {
            products: [],
            lowStockProducts:[],
            bestSellingProducts:[]
        }
    },
    getters: {
        products(state) {
            return (filter) => {
                if(!filter)
                return state.products;
                let filteredData = [...state.products];
                if (filter.name)
                    filteredData = filteredData.filter(x => x.name.toLowerCase().includes(filter.name.toLowerCase()));
                if (filter.brandId)
                    filteredData = filteredData.filter(x => x.brandId == filter.brandId);
                if (filter.sku)
                    filteredData = filteredData.filter(x => x.sku.toLowerCase().startsWith(filter.sku.toLowerCase()));
                return filteredData;
            }
        },
        totalProduct(state) {
            return state.products.length;
        },
        getLowStockProducts(state){
            return state.products.filter(x=>x.avaiableQuantity<9);
        },
        bestSellingProducts(state){
            return state.bestSellingProducts.map(x=>{
                let p= state.products.find(y=>y.id==x.id);
                x.name=p.name;
                x.brandId=p.brandId;
                return x;
            });
        }
    },
    mutations: {
        getProducts(state, products) {
            state.products = products;
        },
        bestSellingProducts(state,bestSellingProducts){
            state.bestSellingProducts=bestSellingProducts;
        }

    },
    actions: {
        async getProducts(context) {
            let productsTask =  productService.getProducts();
            let bestProductsTask =  productService.getBestSellingProducts();
            let [products, bestSellingProducts] = await Promise.all([productsTask,bestProductsTask]);
            context.commit("bestSellingProducts", bestSellingProducts);
            context.commit("getProducts", products);
            
        },
        async saveProduct(context, product) {
            await productService.saveProduct(product);
            context.dispatch("getProducts");
        }
    }

}
export default product;