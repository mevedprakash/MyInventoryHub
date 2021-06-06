<template>
  <!-- Page Heading -->
  <div class="d-sm-flex align-items-center justify-content-between mb-4">
    <h1 class="h3 mb-0 text-gray-800">Dashboard</h1>
    <a href="#" class="d-none d-sm-inline-block btn btn-sm btn-primary"
      ><i class="fas fa-download fa-sm text-white-50"></i> Generate Report</a
    >
  </div>

  <!-- Content Row -->
  <div class="row">
    <!-- Earnings (Monthly) Card Example -->
    <div class="col-xl-3 col-md-6 mb-4">
      <div class="card border-left-primary shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div
                class="text-xs font-weight-bold text-primary text-uppercase mb-1"
              >
                Order Today
              </div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                {{ totalProduct }}
              </div>
            </div>
            <div class="col-auto">
              <router-link
                to="/order/add"
                class="btn btn-sm btn-secondary float-end"
                ><i class="fas fa-calendar fa-2x text-gray-300"></i
              ></router-link>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Earnings (Monthly) Card Example -->
    <div class="col-xl-3 col-md-6 mb-4">
      <div class="card border-left-success shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div
                class="text-xs font-weight-bold text-success text-uppercase mb-1"
              >
                Total Product
              </div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                {{ totalProduct }}
              </div>
            </div>
            <div class="col-auto">
              <router-link
                to="/products"
                class="btn btn-sm btn-secondary float-end"
                ><i class="fas fa-calendar fa-2x text-gray-300"></i
              ></router-link>
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- Earnings (Monthly) Card Example -->
    <div class="col-xl-3 col-md-6 mb-4">
      <div class="card border-left-success shadow h-100 py-2">
        <div class="card-body">
          <div class="row no-gutters align-items-center">
            <div class="col mr-2">
              <div
                class="text-xs font-weight-bold text-success text-uppercase mb-1"
              >
                Total Brands
              </div>
              <div class="h5 mb-0 font-weight-bold text-gray-800">
                {{ totalBrand }}
              </div>
            </div>
            <div class="col-auto">
              <router-link
                to="/brands"
                class="btn btn-sm btn-secondary float-end"
                ><i class="fas fa-calendar fa-2x text-gray-300"></i
              ></router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <div class="row">
    <div class="col-md-6"  v-if="lowStockProducts">
      <Table
        :title="'Low Stock Products'"
        :headers="headers"
        :data="lowStockProducts"
        :pagination="false"
      />
    </div>
     <div class="col-md-6"  v-if="bestSellingProducts">
      <Table
        :title="'Best Selling products in last 30 Days'"
        :headers="headers1"
        :data="bestSellingProducts"
        :pagination="false"
      />
    </div>
    <div class="col-md-6"></div>
  </div>
</template>

<script>
import Table from "@/components/Table.vue";
export default {
  name: "Home",
  data(){
    return {
      headers:[]
    }
  },
  components: {
    Table,
  },
  created() {
    this.headers = [
      {
        display: "Name",
        field: "name"      
      },
      {
        display: "Brand",
        field: "brandId",       
        config: {
          display: (row) => {
            return this.brands.find((x) => x.id == row.brandId)?.name;
          },
        },
      },
      {
        display: "Stock",
        field: "avaiableQuantity",
      },
    ];
      this.headers1 = [
      {
        display: "Name",
        field: "name"      
      },
      {
        display: "Brand",
        field: "brandId",       
        config: {
          display: (row) => {
            return this.brands.find((x) => x.id == row.brandId)?.name;
          },
        },
      },
      {
        display: "Sold Quantity",
        field: "soldQuantity",
      },
    ];
  },
  computed: {
    count() {
      return this.$store.state.count;
    },
    totalProduct() {
      return this.$store.getters.totalProduct;
    },
    totalBrand() {
      return this.$store.getters.totalBrand;
    },
    lowStockProducts() {
      return this.$store.getters.getLowStockProducts;
    },
     brands() {
      return this.$store.getters.brands();
    },
    bestSellingProducts(){
      return this.$store.getters.bestSellingProducts;
    }
  },
  methods: {
    incraese() {
      this.$store.commit("increment");
    },
  },
};
</script>
