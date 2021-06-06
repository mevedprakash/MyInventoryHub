<template>
  <form class="row g-3" v-if="product">
    <div class="col-md-12">
      <label class="form-label">Name</label>
      <input type="text" v-model="productForm.name" class="form-control" />
    </div>

    <div class="col-12">
      <label class="form-label">Detail</label>
      <input type="text" v-model="productForm.detail" class="form-control" />
    </div>
    <div class="col-6">
      <label class="form-label">SKU</label>
      <input type="text" v-model="productForm.sku" class="form-control" />
    </div>
    <div class="col-6">
      <label class="form-label">Brand</label>
      <select v-model="productForm.brandId" class="form-control">
        <option v-for="brand in brands" :key="brand.id" v-bind:value="brand.id">
          {{ brand.name }}
        </option>
      </select>
    </div>
    <div class="col-3">
      <label class="form-label">Purchase Price</label>
      <input type="number" v-model="productForm.purchasePrice" class="form-control" />
    </div>
    <div class="col-3">
      <label class="form-label">Sale Price</label>
      <input type="number" v-model="productForm.salePrice" class="form-control" />
    </div>
    <div class="col-3">
      <label class="form-label">Available Quantity</label>
      <input
        type="text"
        v-model="productForm.avaiableQuantity"
        class="form-control"
      />
    </div>
    <div class="col-3">
      <label class="form-label">Unit of Mesure</label>
      <select v-model="productForm.unitId" class="form-control">
        <option v-for="unit in units" :key="unit.id" v-bind:value="unit.id">
          {{ unit.name }}
        </option>
      </select>
    </div>
    <div class="col-12">
      <div class="form-check">
        <input
          v-model="productForm.isActive"
          class="form-check-input"
          type="checkbox"
        />
        <label class="form-check-label"> Check For Active </label>
      </div>
    </div>
    <div class="col-12">
      <button
        type="button"
        @click="saveproduct"
        class="btn btn-sm btn-primary  float-end"
      >
        Save
      </button>
    </div>
  </form>
</template>
<script>
export default {
  props: {
    product: Object,
    brands: Array,
    units: Array,
  },
  data: function () {
    return {
      productForm: { ...this.product },
    };
  },
  created() {
    console.log(this.product, this.productForm);
  },
  methods: {
    async saveproduct() {
      this.$emit("saveProduct", this.productForm);
    },
  },
};
</script>