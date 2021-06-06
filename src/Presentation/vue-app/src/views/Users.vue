<template>
      <h2>User Management</h2>
      <div class="table-responsive">
        <table class="table table-striped table-sm">
          <thead>
            <tr>
              <th>#</th>
              <th>Name</th>
              <th>Detail</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="brand in brands" :key="brand.id">
              <td>{{brand.id}}</td>
              <td>{{brand.name}}</td>              
              <td>{{brand.detail}}</td>              
            </tr>          
          </tbody>
        </table>
      </div>
</template>
<script>
import brandService from '@/services/brandService'
export default {
  data(){
    return {
     brands:[]
    }
  },
  created(){
   this.getBrands();
  },
  methods:{
    async getBrands(){
       this.brands=await brandService.getBrands();
    }
  }
}
</script>