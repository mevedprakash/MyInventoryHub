<template>
  <Table
    v-if="products"
    :title="'Product Master'"
    :headers="headers"
    :data="products"
    @onAdd="addProduct"
    @onEdit="editProduct"
    @filter="onFilterChange"
    :pagination="true"
  ></Table>
  <modal v-if="isModalVisible" @close="closeModal">
    <template v-slot:header><h6>Add/Update product</h6> </template>
    <template v-slot:body>
      <ProductForm
        :product="productForm"
        :brands="brands"
        :units="units"
        @saveProduct="saveProduct"
      />
    </template>
    <template v-slot:footer></template>
  </modal>
</template>
<script>
import Modal from "@/components/Modal.vue";
import ProductForm from "@/components/ProductForm.vue";
import toastService from "@/services/toastService";
import Table from "@/components/Table.vue";
export default {
  data() {
    return {
      headers: [],
      isModalVisible: false,
      productForm: {},
      filter: {},
    };
  },

  async created() {
    this.headers = [
      {
        display: "#",
        field: "id",
      },
      {
        display: "Name",
        field: "name",
        filter: {
          type: "text",
        },
      },
      {
        display: "Detail",
        field: "detail"       
      },
      {
        display: "Brand",
        field: "brandId",
        filter: {
          type: "singleSelect",
          data: this.brands,
          key: "id",
          value: "name",
        },
        config: {
          display: (row) => {
            return this.brands.find((x) => x.id == row.brandId)?.name;
          },
        },
      },
      {
        display: "Sku",
        field: "sku",
        filter: {
          type: "text",
        },
      },
      {
        display: "Purchase price",
        field: "purchasePrice",
      },
      {
        display: "Sale price",
        field: "salePrice",
      },
      {
        display: "Stock",
        field: "avaiableQuantity",
      },
      {
        display: "",
        field: "",
        config: {
          isAction: true,
          action:["edit","add","delete"]
        },
      },
    ];
  },
  computed: {
    brands() {
      return this.$store.getters.brands();
    },
    products() {
      return this.$store.getters.products(this.filter);
    },
    units() {
      return this.$store.getters.units;
    },
  },
  methods: {
    addProduct() {
      this.productForm = {
        id: 0,
      };
      this.isModalVisible = true;
    },
    editProduct(product) {
      this.productForm = { ...product };
      this.isModalVisible = true;
    },
    async saveProduct(product) {
      this.$store.dispatch("saveProduct", product);
      toastService.success("saved");
      this.closeModal();
    },
    closeModal() {
      this.isModalVisible = false;
    },
    onFilterChange(filters) {
      this.filter={};
      for (let filter in filters) {
        console.log("filter",filter);
        this.filter[filter]=filters[filter].value;
      }
    },
  },
  components: {
    Modal,
    ProductForm,
    Table,
  },
};
</script>