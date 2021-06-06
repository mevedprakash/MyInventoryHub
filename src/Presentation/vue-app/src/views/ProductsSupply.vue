<template>
      <h2>Product Supply</h2>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <tr>
              <th>#</th>
              <th>productId</th>
              <th>mrp</th>
              <th>price</th>
              <th>quantity</th>
              <th>discount</th>
              <th>tax</th>
              <th>subTotalAmount</th>
              <th>totalAmount</th>
              
            </tr>
          </thead>
          <tbody>
            <tr v-for="brand in brands" :key="brand.id">
              <td>{{brand.id}}</td>
              <td>{{brand.productId}}</td> 
              <td>{{brand.mrp}}</td>              
              <td>{{brand.detail}}</td>              
               <td>{{brand.price}}</td>
              <td>{{brand.discount}}</td>              
              <td>{{brand.tax}}</td>              
               <td>{{brand.subTotalAmount}}</td>
              <td>{{brand.totalAmount}}</td>              
                           
            </tr>          
          </tbody>
        </table>
      </div>
</template>
<script>
import inventoryService from '@/services/inventoryService'
export default {
  data(){
    return {
     brands:[]
    }
  },
  created(){
   this.getSupplies();
  },
  methods:{
    async getSupplies(){
       this.brands=await inventoryService.getProductSuppllies();
    }
  }
}
</script>