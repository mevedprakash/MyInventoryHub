<template>
  <SideMenu v-if="this.$route.name!='Login'"></SideMenu>
  <div v-if="this.$route.name!='Login'" id="content-wrapper" class="d-flex flex-column">
    <!-- Main Content -->
    <div id="content">
      <NavBar @signout="onSignout" />

      <!-- Begin Page Content -->
      <div class="container-fluid">
        <router-view />
      </div>
    </div>
    <footer class="sticky-footer bg-white">
      <div class="container my-auto">
        <div class="copyright text-center my-auto">
          <span>Copyright &copy; Your Website 2020</span>
        </div>
      </div>
    </footer>
  </div>
  <router-view v-if="this.$route.name=='Login'" />
</template>
<script>
// @ is an alias to /src
import NavBar from "@/components/NavBar.vue";
import SideMenu from "@/components/SideMenu.vue";
import router from "@/router";
export default {
  name: "App",
  components: {
    NavBar,
    SideMenu,
  },
  mounted() {
    this.$store.dispatch("getProducts");
    this.$store.dispatch("getBrands");
    this.$store.dispatch("getUnits");
    this.$store.dispatch("getPaymentTypes");
    this.$store.dispatch("getStore");
  },
  methods: {
    onSignout(value) {
      console.log("logout", value);
      localStorage.removeItem("user");
      router.push("/login");

    },
  },
};
</script>
<style lang="scss">
</style>
