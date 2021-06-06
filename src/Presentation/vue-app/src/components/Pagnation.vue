<template>
  <nav>
    <ul class="pagination justify-content-center mb-0">
      <li class="page-item ">
        <a class="page-link" @click="goToPage(1)">First</a>
      </li>
      <li class="page-item " v-bind:class="{ disabled: currentPage == 1 }">
        <a class="page-link" @click="goToPage(currentPage - 1)">Previous</a>
      </li>
      <li
        v-for="page in pages"
        :key="page"
        class="page-item "
        v-bind:class="{ active: page == currentPage }"
      >
        <a
          class="page-link"
          :disabled="page == currentPage"
          @click="goToPage(page)"
          >{{ page }}</a
        >
      </li>

      <li
        class="page-item "
        v-bind:class="{ disabled: currentPage >= totalPages }"
      >
        <a class="page-link" @click="goToPage(currentPage + 1)">Next</a>
      </li>
      <li class="page-item ">
        <a class="page-link" @click="goToPage(totalPages)">Last</a>
      </li>
    </ul>
  </nav>
</template>
<script>
export default {
  props: {
    previous: Boolean,
    next: Boolean,
    currentPage: {
      default: 1,
      type: Number,
    },
    maxVisibleButtons: {
      type: Number,
      required: false,
      default: 3,
    },
    totalPages: {
      type: Number,
      required: true,
    },
  },
  computed: {
    startPage() {
      let mid = 0;
      if (this.maxVisibleButtons%2==0)
        mid = Math.floor(this.maxVisibleButtons / 2) - 1;
      else
        mid = Math.floor(this.maxVisibleButtons / 2);
      if (this.currentPage - mid <= 0) {
        return 1;
      }
      if (this.currentPage === this.totalPages) {
        return Math.max(1, this.totalPages - this.maxVisibleButtons + 1);
      }
      return this.currentPage - mid;
    },
    pages() {
      const range = [];
      for (
        let i = this.startPage;
        i <=
        Math.min(this.startPage + this.maxVisibleButtons - 1, this.totalPages);
        i += 1
      ) {
        range.push(i);
      }
      return range;
    },
  },
  methods: {
    goToPage(page) {
      this.$emit("goToPage", page);
    },
  },
};
</script>
