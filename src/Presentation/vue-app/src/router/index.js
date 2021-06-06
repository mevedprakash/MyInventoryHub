import { createRouter, createWebHistory } from 'vue-router'
import Home from '../views/Home.vue'
import Login from '../views/Login.vue'
import Brands from '../views/Brands.vue'
import Products from '../views/Products.vue'
import Orders from '../views/Orders.vue'
import OrderForm from '../views/OrderForm.vue'
import ProductsSupply from '../views/ProductsSupply.vue'
const routes = [
  {
    path: '/',
    name: 'Home',
    component: Home,
    beforeEnter : authGaurd,
  },
  {
    path: '/login',
    name: 'Login',
    component: Login
  },
  {
    path: '/brands',
    name: 'Brands',
    component: Brands,
    beforeEnter : authGaurd,
  },
  {
    path: '/products',
    name: 'Products',
    component: Products,
    beforeEnter : authGaurd,
  },
  {
    path: '/orders',
    name: 'Orders',
    component: Orders,
    beforeEnter : authGaurd,
  },
  {
    path: '/order/add',
    name: 'OrderForm',
    component: OrderForm,
    beforeEnter : authGaurd,
  },
  {
    path: '/order/:id',
    name: 'OrderForm1',
    component: OrderForm,
    beforeEnter : authGaurd,
    props: true
  },
  {
    path: '/productsupply',
    name: 'ProductsSupply',
    component: ProductsSupply,
    beforeEnter : authGaurd,
  },
  {
    path: '/users',
    name: 'User',
    component: () => import(/* webpackChunkName: "about" */ '../views/Users.vue'),
    beforeEnter : authGaurd,
  },
  {
    path: '/store',
    name: 'Store',
    component: () => import('../views/Store.vue'),
    beforeEnter : authGaurd,
  },
  {
    // path: "*",
    path: "/:catchAll(.*)",
    name: "NotFound",
    component: Home,
    meta: {
      requiresAuth: false
    }
  }
]

const router = createRouter({
  history: createWebHistory(process.env.BASE_URL),
  routes
})
function authGaurd (to, from, next) {
  const loggedIn = localStorage.getItem('user');
  console.log(loggedIn);
  if (!loggedIn) {
    return next('/login');
  }
  next();
}
export default router
