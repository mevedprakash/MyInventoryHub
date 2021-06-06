<template>
  <div class="card">
    <div class="card-header pb-0"><h6 class="card-title">Create store</h6></div>
    <div class="card-body">
      <form v-if="store">
        <div class="form-row">
          <div class="form-group col-md-6">
            <label class="form-label">Store Name</label>
            <input type="text" v-model="store.name" class="form-control" />
          </div>

          <div class="form-group col-md-6">
            <label class="form-label">Store Email</label>
            <input type="text" v-model="store.email" class="form-control" />
          </div>
        </div>
        <div class="form-group">
          <label for="inputAddress">Address</label>
          <input
            type="text"
            class="form-control"
            v-model="store.addressLine1"
            placeholder=""
          />
        </div>
        <div class="form-group">
          <label for="inputAddress2">Address 2</label>
          <input
            type="text"
            class="form-control"
            v-model="store.addressLine2"
            placeholder=""
          />
        </div>
        <div class="form-row">
          <div class="form-group col-md-6">
            <label for="inputCity">City</label>
            <input type="text" 
            v-model="store.city"
            class="form-control" />
          </div>
          <div class="form-group col-md-4">
            <label for="inputState">State</label>
             <input type="text" 
            v-model="store.state"
            class="form-control" />
          </div>
          <div class="form-group col-md-2">
            <label for="inputZip">Zip</label>
            <input type="text"  v-model="store.pinCode"
             class="form-control"  />
          </div>      
        </div>

        <div class="col-12">
          <button
            type="button"
            @click="savestore"
            class="btn btn-sm btn-primary float-right"
          >
            Save
          </button>
        </div>
      </form>
    </div>
  </div>
</template>
<script>
import apiService from "@/services/api";
import toastService from "@/services/toastService";
export default {
  props: {
    id: { required: false },
  },
  data: function () {
    return {
      store: null,
    };
  },
  async created() {
    this.store = { ...this.$store.getters.store };
  },
  methods: {
    async savestore() {
      await apiService.saveStore({...this.store});
      this.$store.dispatch("getStore");
      toastService.success("Store details have beend saved successfuly.");
    },
  },
};
</script>