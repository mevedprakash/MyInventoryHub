<template>
  <div class="card shadow mb-4">
    <div class="card-header py-3">
      <h6 class="m-0 font-weight-bold">
        {{ title }}
        <button v-if="showAdd" @click="add" class="btn btn-primary btn-circle btn-sm float-right">
          <i class="fas fa-plus-circle pull-right"></i>
        </button>
      </h6>
    </div>
    <div class="card-body p-0">
      <div
        v-if="data"
        class="table-responsive"
        v-bind:class="{ scrollTable: !pagination }"
      >
        <table class="table table-bordered">
          <thead>
            <tr>
              <th v-for="(col, j) in headers" :key="j">
                <span>{{ col.display }}</span>
              </th>
            </tr>
            <tr v-if="pagination">
              <th v-for="(col, j) in headers" :key="j">
                <input
                  v-if="col.filter && col.filter.type == 'text'"
                  @input="
                    onChange(col.field, col.filter.type, $event.target.value)
                  "
                  type="text"
                  class="form-control"
                />
                <select
                  v-if="col.filter && col.filter.type == 'singleSelect'"
                  @change="
                    onChange(col.field, col.filter.type, $event.target.value)
                  "
                  class="form-control"
                >
                  <option value="">Select</option>
                  <option
                    v-for="d in col.filter.data"
                    :key="d[col.filter.key || 'key']"
                    v-bind:value="d[col.filter.key || 'key']"
                  >
                    {{ d[col.filter.value || "value"] }}
                  </option>
                </select>
              </th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="row in filteredData" :key="row.id">
              <td v-for="(col, j) in headers" :key="j">
                <span v-if="!col.config">{{ row[col.field] }}</span>
                <div
                  v-if="col.config && col.config.display"
                  v-html="col.config.display(row)"
                ></div>
                <div v-if="col.config && col.config.isAction">
                  <div class="pull-right">
                    <button v-if="col.config.action?.includes('edit')"
                      @click="edit(row)"
                      class="btn btn-warning btn-circle btn-sm"
                    >
                      <i class="fas fa-edit"></i>
                    </button>
                    <button v-if="col.config.action?.includes('delete')" class="btn btn-danger btn-circle btn-sm">
                      <i class="fas fa-trash-alt"></i>
                    </button>
                  </div>
                </div>
              </td>
            </tr>
            <tr v-if="!filteredData || filteredData.length == 0">
              <td v-bind:colSpan="headers.length">No records found</td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <div class="card-footer">
      <Pagination
        v-if="pagination"
        :currentPage="currentPage"
        :totalPages="totalPage"
        @goToPage="goToPage"
      />
    </div>
  </div>
</template>
<script>
import Pagination from "./Pagnation.vue";
export default {
  props: {
    title: String,
    isLoading: Boolean,
    pagination: {
      default: false,
      type: Boolean,
    },
    isLazyLoading: {
      default: false,
      type: Boolean,
    },
    headers: Array,
    data: Array,
    pageSize: {
      default: 5,
      type: Number,
    },
  },
  emits: ["onAdd", "onEdit"],
  data() {
    return {
      filter: {},
      filteredData: [],
      currentPage: 1,
      totalPage: 0,
    };
  },
  computed:{
    showAdd(){
      return this.headers.find(x=>x.field == "" && x.config.isAction && x.config.action?.includes("add"))
    }
  },
  created() {
    this.handleChange();
    this.$watch(() => this.data, this.handleChange, { deep: true });
  },
  methods: {
    handleChange() {
      console.log("data", this.data);
      if (this.pagination && !this.isLazyLoading) {
        this.totalPage = Math.ceil(this.data.length / this.pageSize);
        console.log("totalPage", this.totalPage);
        this.updateFilterdData();
      } else {
        this.filteredData = [...this.data];
      }
      console.log(this.data);
      console.log(this.headers, this.pagination);
    },
    async edit(row) {
      console.log("edit", row);
      this.$emit("onEdit", row);
    },
    async add() {
      this.$emit("onAdd");
    },
    goToPage(page) {
      console.log(page);
      if (page < 1 || page > this.totalPage) {
        return;
      }
      this.currentPage = page;
      if (!this.isLazyLoading) {
        this.updateFilterdData();
      }
    },
    updateFilterdData() {
      this.filteredData = this.data.slice(
        (this.currentPage - 1) * this.pageSize,
        (this.currentPage - 1) * this.pageSize + this.pageSize
      );
    },
    onChange(key, type, value) {
      if (!value) {
        delete this.filter[key];
      } else {
        console.log(key, type, value, this.filter);
        if (this.filter[key] && this.filter[key].value)
          this.filter[key].oldValue = this.filter[key].value;
        if (this.filter[key]) this.filter[key].value = value;
        else this.filter[key] = { value: value };
      }
      this.$emit("filter", this.filter);
    },
    debounce(fn) {
      console.log(fn);
      var delay = 250;
      var timeoutID = null;
      return function () {
        clearTimeout(timeoutID);
        var args = arguments;
        var that = this;
        timeoutID = setTimeout(function () {
          fn.apply(that, args);
        }, delay);
      };
    },
  },
  components: {
    Pagination,
  },
};
</script>
<style lang="scss">
.scrollTable {
  height: 360px;
  overflow: auto;
  thead tr th {
    position: sticky;
    top: 0;
  }
  table {
    border-collapse: collapse;
  }
  th {
    border-left: 1px dotted rgba(200, 209, 224, 0.6);
    border-bottom: 1px solid #e8e8e8;
    background: #ffc491;
    text-align: left;
    box-shadow: 0px 0px 0 2px #e8e8e8;
  }
}
</style>