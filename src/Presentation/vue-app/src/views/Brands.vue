<template>
  <Table
    :title="'Brand Master'"
    :headers="headers"
    :data="brands"
    @onAdd="addBrand"
    @onEdit="editBrand"
    :pagination="true"
    @filter="onFilterChange"
  ></Table>
  <modal v-if="isModalVisible" @close="closeModal">
    <template v-slot:header><h6>Add/Update Brand</h6> </template>
    <template v-slot:body>
      <BrandForm :brand="brandForm" @savebrand="saveBrand" />
    </template>
    <template v-slot:footer></template>
  </modal>
</template>

<script>
import Modal from "@/components/Modal.vue";
import BrandForm from "@/components/BrandForm.vue";
import Table from "@/components/Table.vue";
import toastService from "@/services/toastService";
export default {
  data() {
    return {
      isModalVisible: false,
      brandForm: {},
      headers: [],
      filter:{}
    };
  },
  computed: {
    brands() {
      return this.$store.getters.brands(this.filter);
    },
  },
  created() {
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
        field: "detail",
      },
      {
        display: "Status",
        field: "isActive",
        config: {
          display: function (row) {
            if (row.isActive) return "Active";
            return "InActive";
          },
        },
      },
      {
        display: "",
        field: "",
        config: {
          isAction: true,
          action:["edit","add"]
        },
      },
    ];
  },
  methods: {
    addBrand() {
      this.brandForm = {
        name: "",
        detail: "",
        imagId: 0,
        isActive: true,
      };
      this.isModalVisible = true;
    },
    editBrand(brand) {
      console.log("editBrand", brand);
      this.brandForm = { ...brand };
      this.isModalVisible = true;
    },
    async saveBrand(brand) {
      this.$store.dispatch("saveBrand", brand);
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
    BrandForm,
    Table,
  },
};
</script>