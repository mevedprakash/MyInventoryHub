<template>
  <!-- Sidebar -->
  <ul
    class="navbar-nav bg-gradient-primary sidebar sidebar-dark accordion"
    v-bind:class="{ toggled: !fullSidebar }"
  >
    <!-- Sidebar - Brand -->
    <a
      class="sidebar-brand d-flex align-items-center justify-content-center"
      href="/"
    >
      <div class="sidebar-brand-icon">
        <img class="rounded" width="32" src="https://source.unsplash.com/user/erondu/240x240">
      </div>
      <div class="sidebar-brand-text ml-1">{{store.name}}</div>
    </a>

    <!-- Divider -->
    <hr class="sidebar-divider my-0" />

    <!-- Nav Item - Dashboard -->
    <li class="nav-item">
      <router-link class="nav-link" to="/">
        <i class="fas fa-fw fa-tachometer-alt"></i>
        <span>Dashboard</span>
      </router-link>
    </li>

    <!-- Divider -->
    <hr class="sidebar-divider" />
   

    <!-- Nav Item - Charts -->
    <li class="nav-item">
      <router-link class="nav-link" to="/orders">
        <i class="fas fa-fw fa-chart-area"></i><span>Orders</span></router-link
      >
    </li>
    <li class="nav-item">
      <router-link class="nav-link" to="/products">
        <i class="fas fa-fw fa-chart-area"></i>
        <span>Products</span></router-link
      >
    </li>
    <li class="nav-item">
      <router-link class="nav-link" to="/brands">
        <i class="fas fa-fw fa-chart-area"></i><span>Brands</span></router-link
      >
    </li>
    <!-- Divider -->
     <!-- Heading -->
    <div class="sidebar-heading">Setting</div>
    <li class="nav-item">
      <router-link class="nav-link" to="/store">
        <i class="fas fa-fw fa-chart-area"></i><span>Store Setting</span></router-link
      >
    </li>
    <hr class="sidebar-divider d-none d-md-block" />
    <!-- Sidebar Toggler (Sidebar) -->
    <div class="text-center d-none d-md-inline">
      <button
        class="rounded-circle border-0 shadow"
        @click="toggleSidebar"
        id="sidebarToggle"
      ></button>
    </div>
  </ul>
  <!-- End of Sidebar -->
</template>
<script>
export default {
  data() {
    return {
      fullSidebar: true,
    };
  },
  computed:{
  store(){
    return this.$store.getters.store || {};
  }
  },
  methods: {
    toggleSidebar() {
      this.fullSidebar = !this.fullSidebar;
    },
  },
};
</script>