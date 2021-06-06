<template>
  <div class="container">
    <!-- Outer Row -->
    <div class="row justify-content-center">
      <div class="col-xl-10 col-lg-12 col-md-9">
        <div class="card o-hidden border-0 shadow-lg my-5">
          <div class="card-body p-0">
            <!-- Nested Row within Card Body -->
            <div class="row">
             
              <div class="col-lg-12">
                <div class="p-5">
                  <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                  </div>
                  <form class="user" @submit.prevent="onlogin">
                    <div class="form-group">
                      <input
                        v-model="email"
                        type="email"
                        class="form-control "
                        id="exampleInputEmail"
                        aria-describedby="emailHelp"
                        placeholder="Enter Email Address..."
                      />
                    </div>
                    <div class="form-group">
                      <input
                        v-model="password"
                        type="password"
                        class="form-control "
                        id="exampleInputPassword"
                        placeholder="Password"
                      />
                    </div>
                    <div class="form-group">
                      <div class="custom-control custom-checkbox small">
                        <input
                          type="checkbox"
                          class="custom-control-input"
                          id="customCheck"
                        />
                        <label class="custom-control-label" for="customCheck"
                          >Remember Me</label
                        >
                      </div>
                    </div>
                    <button
                      type="submit"
                      class="btn btn-primary  btn-block "
                    >
                      Login
                    </button>
                  </form>
                  <hr />
                  <div class="text-center">
                    <a class="small" href="/forgot-password"
                      >Forgot Password?</a
                    >
                  </div>
                  <div class="text-center">
                    <a class="small" href="/register">Create an Account!</a>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import authService from "@/services/authService";
import router from "@/router";
export default {
  data() {
    return {
      email: "",
      password: "",
      submitted: false,
    };
  },
  created() {
    // reset login status

    console.log("in login",this.$route.name);
  },
  methods: {
    onlogin() {
      this.submitted = true;
      const { email, password } = this;
      if (email && password) {
        this.login({ email, password });
      }
    },
    logout() {},
    login(data) {
      authService.login(data.email, data.password).then((result) => {
        console.log(result);
        router.push("/");
      });
    },
  },
};
</script>
<style lang="scss">
.form-signin {
  width: 100%;
  max-width: 360px;
  padding: 10px;
  margin: auto;
}
</style>