import Vue from 'vue'
import App from './App.vue'
import axios from 'axios';
import BootstrapVue from "bootstrap-vue";
import vuetify from './plugins/vuetify'

Vue.config.productionTip = false
axios.defaults.baseURL = "http://localhost:8000/api";
Vue.use(BootstrapVue);

new Vue({
  vuetify,
  render: h => h(App)
}).$mount('#app')
