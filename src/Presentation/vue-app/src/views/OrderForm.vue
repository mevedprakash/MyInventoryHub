<template>
  <div class="card">
    <div class="card-header pb-0"><h6 class="card-title">Create order</h6></div>
    <div class="card-body">
      <form v-if="order">
        <div class="form-row">
          <div class="form-group col-6">
            <label class="form-label">Customer Name</label>
            <input
              type="text"
              v-model="order.customer.name"
              class="form-control"
            />
          </div>

          <div class="form-group col-6">
            <label class="form-label">Customer Mobile</label>
            <input
              type="text"
              v-model="order.customer.mobileNo"
              class="form-control"
            />
          </div>
          <div class="form-group col-6">
            <label class="form-label">Order No.</label>
            <input type="text" v-model="order.orderNo" class="form-control" />
          </div>

          <div class="form-group col-6">
            <label class="form-label">Order Date</label>
            <input type="text" v-model="order.createdAt" class="form-control" />
          </div>
          <div class="form-group col-3">
            <label class="form-label">Invoice Type</label>
            <select v-model="order.invoiceType" class="form-control">
              <option v-bind:value="1">Non Taxable</option>
              <option v-bind:value="2">Taxable</option>
            </select>
          </div>
          <div class="form-group col-12">
            <div class="card">
              <div class="card-header pb-0">
                <h6 class="card-title">Add new item</h6>
              </div>
              <div class="card-body">
                <div class="row">
                  <div class="col-6">
                    <select
                      v-model="item.productId"
                      @change="onProductChange($event, item)"
                      class="form-control"
                    >
                      <option value="">Select Product</option>
                      <option
                        v-for="product in products"
                        :key="product.id"
                        v-bind:value="product.id"
                      >
                        {{ product.name }}
                      </option>
                    </select>
                  </div>
                  <div class="col-3">
                    <input
                      v-model="item.quantity"
                      @change="updateLineItem('quantity', item)"
                      type="text"
                      class="form-control"
                    />
                  </div>
                  <div class="col-3">
                    <button
                      type="button"
                      @click="addItem"
                      class="btn btn-primary float-right"
                    >
                      Add
                    </button>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="form-group col-12">
            <h5>Order Items</h5>
            <div class="table-responsive">
              <table class="table table-bordered table-sm">
                <thead>
                  <tr>
                    <th>#</th>
                    <th>Product</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Sub Amount</th>
                    <th>Discount</th>
                    <th v-show="order.invoiceType == 2">Tax</th>
                    <th>Net Amount</th>
                    <th>
                      <i
                        @click="addItem"
                        class="bi bi-plus-circle-fill text-primary float-end"
                        style="font-size: 1.3rem"
                      ></i>
                    </th>
                  </tr>
                </thead>
                <tbody>
                  <tr v-for="(item, i) in order.orderItems" :key="i">
                    <td class="table-input">{{ i + 1 }}</td>
                    <td class="table-input">
                      {{ item.productName }}
                    </td>
                    <td class="table-input">
                      <input
                        type="text"
                        v-model="item.priceRate"
                        @change="updateLineItem('quantity', item)"
                        class="input-control"
                      />
                    </td>
                    <td class="table-input">
                      <input
                        type="text"
                        v-model="item.quantity"
                        @change="updateLineItem('quantity', item)"
                        class="input-control"
                      />
                    </td>
                    <td class="table-input">
                      {{ item.subAmount }}
                    </td>
                    <td class="table-input">
                      <input
                        type="text"
                        v-model="item.discount"
                        @change="updateLineItem('quantity', item)"
                        class="input-control"
                      />
                    </td>
                    <td v-show="order.invoiceType == 2" class="table-input">
                      {{ item.tax }}
                    </td>
                    <td class="table-input">
                      {{ item.netAmount }}
                    </td>
                    <td class="table-input">
                      <i
                        @click="deleteItem(i)"
                        class="fas fa-trash-alt float-end"
                      ></i>
                    </td>
                  </tr>

                  <hr />
                  <tr>
                    <th colspan="5"></th>
                    <th>Sub Total:</th>
                    <th colspan="2">
                      {{order.subAmount}}
                    </th>
                  </tr>
                  <tr>
                    <th colspan="5"></th>
                    <th>Discount on order:</th>
                    <th colspan="2">
                      {{order.discount}}
                    </th>
                  </tr>
                  <tr v-show="order.invoiceType == 2">
                    <th colspan="5"></th>
                    <th>Tax:</th>
                    <th colspan="2">
                      {{order.tax}}
                    </th>
                  </tr>
                  <tr>
                    <th colspan="5"></th>
                    <th>Net Amount:</th>
                    <th colspan="2">
                      {{order.netAmount}}
                    </th>
                  </tr>
                  <tr>
                    <th class="table-input" colspan="5"></th>
                    <th class="table-input">Payment Type:</th>
                    <th colspan="2" class="table-input">
                      <select v-model="order.payment.type" class="input-control">
                        <option value="">Pending</option>
                        <option
                          v-for="type in paymentTypes"
                          :key="type.value"
                          v-bind:value="type.value"
                        >
                          {{ type.text }}
                        </option>
                      </select>
                    </th>
                  </tr>
                </tbody>
              </table>
            </div>
          </div>
          <div class="col-12">
            <button
              type="button"
              @click="saveOrder"
              class="btn btn-sm btn-primary float-end"
            >
              Save
            </button>
          </div>
        </div>
      </form>
    </div>
  </div>
</template>
<script>
import inventoryService from "@/services/inventoryService";
import toastService from "@/services/toastService";
import router from "@/router";
export default {
  props: {
    id: { required: false },
  },
  data: function () {
    return {
      order: null,
      item: {},
    };
  },
  computed: {
    products() {
      return this.$store.getters.products();
    },
    paymentTypes() {
      return this.$store.getters.paymentTypes;
    },
  },
  async created() {
    console.log("orderId", this.id);
    if (this.id) this.order = await this.getOrder(this.id);
    else {
      this.order = {
        invoiceType: 1,
        customer: {},
        payment: {},
        orderItems: [],
      };
    }
  },
  methods: {
    async getOrder(orderId) {
      var order = await inventoryService.getOrder(orderId);
      order.orderItems = order.orderItems.map((x) => {
        x.productName = this.products.find((p) => p.id == x.productId)?.name;
        return x;
      });
      if (!order.payment) order.payment = {};
      return order;
    },
    async saveOrder() {
      await inventoryService.saveOrder(this.order);
      this.$store.dispatch("getProducts");
      toastService.success("saved");
      router.push("/orders");
    },
    addItem() {
      let oldItem = this.order.orderItems.find(
        (x) => x.productId == this.item.productId
      );
      if (oldItem) {
        oldItem.quantity += this.item.quantity;
        oldItem.discount += this.item.discount;
        this.updateLineItem("quanity", oldItem);
      } else {
        this.order.orderItems.push({ ...this.item });
      }

      this.item = {};
      this.updateOrder();
    },
    deleteItem(index) {
      this.order.orderItems.splice(index, 1);
      this.updateOrder();
    },
    onProductChange(event, item) {
      let productId = event.target.value;
      item.priceRate = this.products.find((x) => x.id == productId).salePrice;
      item.quantity = 1;
      this.updateLineItem("quantity", item);
    },
    updateLineItem(changeField, item) {
      console.log(changeField);
      if (!item.discount) item.discount = 0;
      else item.discount = +item.discount;
      if (!item.tax) item.tax = 0;
      else item.tax = +item.tax;
      if (!item.quantity) item.quantity = 0;
      else item.quantity = +item.quantity;
      item.priceRate = +item.priceRate;
      if (changeField == "priceRate") {
        item.subAmount = item.priceRate * item.quantity;
        item.netAmount = item.subAmount - item.discount + item.tax;
      } else if (changeField == "quantity") {
        item.subAmount = item.priceRate * item.quantity;
        item.netAmount = item.subAmount - item.discount + item.tax;
      } else if (changeField == "discount") {
        item.subAmount = item.priceRate * item.quantity;
        item.netAmount = item.subAmount - item.discount + item.tax;
      } else {
        item.subAmount = item.priceRate * item.quantity;
        item.netAmount = item.subAmount - item.discount + item.tax;
      }
    },
    updateOrder() {
      this.order.subAmount = this.order.orderItems
        .map((item) => item.netAmount)
        .reduce((prev, next) => prev + next, 0);

      if (!this.order.discount) this.order.discount = 0;
      if (!this.order.tax) this.order.tax = 0;
      else this.order.tax = +this.order.tax;
      this.order.netAmount =
        this.order.subAmount - this.order.discount + this.order.tax;
    },
  },
};
</script>