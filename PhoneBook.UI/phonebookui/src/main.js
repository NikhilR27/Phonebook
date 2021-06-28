import Vue from 'vue'
import App from './App.vue'
import axios from 'axios';
import BootstrapVue from "bootstrap-vue";

Vue.config.productionTip = false
axios.defaults.baseURL = "http://localhost:8000/api";
Vue.use(BootstrapVue);

new Vue({
  render: h => h(App),
}).$mount('#app')
