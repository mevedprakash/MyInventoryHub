<template>
  <form class="row g-3" v-if="brand">
    <div class="col-md-12">
      <label class="form-label">Name</label>
      <input type="text" v-model="brandForm.name" class="form-control" />
    </div>

    <div class="col-12">
      <label class="form-label">Detail</label>
      <input type="text" v-model="brandForm.detail" class="form-control" />
    </div>

    <div class="col-12">
      <div class="form-check">
        <input
          v-model="brandForm.isActive"
          class="form-check-input"
          type="checkbox"
        />
        <label class="form-check-label"> Check For Active </label>
      </div>
    </div>
    <div class="col-12">
      <button
        type="button"
        @click="saveBrand"
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
    brand: Object,
  },
  data: function () {
        return {
            brandForm: {...this.brand}
        }
    },
    created(){
        console.log(this.brand,this.brandForm);
    },
  methods: {
    async saveBrand() {
      this.$emit("savebrand", this.brandForm);
    },
  },
};
</script>