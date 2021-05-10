import Vue from 'vue'
import App from './App.vue'
import VueRouter from 'vue-router'

// Thêm ác thành phần được sử dụng trong Vue-Router
import employee from './components/view/employee.vue'
import notemployee from './components/view/notemployee.vue'




Vue.config.productionTip = false

const routes =[
  {path:"/employee",component:employee},
  {path:"/notemployee",component:notemployee},
]; 

const router = new VueRouter({
  routes
}); 

Vue.use(VueRouter);

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
