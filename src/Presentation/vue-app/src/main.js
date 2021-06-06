import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import './assets/style.scss'
import store from './store';
import "startbootstrap-sb-admin-2/vendor/fontawesome-free/css/all.min.css"
import usePrimeVue from './PrimeVue'
let app=createApp(App).use(router).use(store);
usePrimeVue(app);
app.mount('#wrapper')
