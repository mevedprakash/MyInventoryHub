<template>
  <Table
    v-if="orders"
    :title="'Order'"
    :headers="headers"
    :data="orders"
    @onAdd="addOrder"
    @onEdit="editOrder"
    :pagination="true"
  ></Table>
</template>
<script>
import inventoryService from "@/services/inventoryService";
import Table from "@/components/Table.vue";
import router from "@/router";
export default {
  data() {
    return {
      orders: null,
      headers: [],
    };
  },
  created() {
    this.headers = [
      {
        display: "#",
        field: "id",
      },
      {
        display: "Customer",
        field: "customer.name",
        config: {
          display: function(row){
             return row.customer?.name;
          }
        },
      },
      {
        display: "subAmount",
        field: "subAmount",
      },
      {
        display: "discount",
        field: "discount",
      },
      {
        display: "tax",
        field: "tax",
      },
      {
        display: "netAmount",
        field: "netAmount",
      },
      {
        display: "Order Date",
        field: "createdAt",
      },
      {
        display: "Payment Status",
        field: "payment.status",
        config: {
          display: function(row){
             return (row.payment && row.payment.status==3)?"Paid":"Unpaid";
          }
        },
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
    this.getOrders();
  },
  methods: {
    async getOrders() {
      let result = await inventoryService.getOrders();
      this.orders = result.data;
    },
    addOrder() {
      router.push("/order/add");
    },
    editOrder(order) {
      router.push("/order/" + order.id);
    },
  },
  components: {
    Table,
  },
};
</script>