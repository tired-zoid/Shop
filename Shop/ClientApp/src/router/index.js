import Vue from "vue";
import VueRouter from "vue-router";
import vCatalog from '../components/v-catalog.vue'
import vCart from '../components/v-cart.vue'
import vAdmin from '../components/v-admin.vue'
import vInfo from '../components/v-info.vue'


Vue.use(VueRouter);

const routes = [
  {
    path: '/',
    name: 'catalog',
    component: vCatalog
  },
  {
    path: '/cart',
    name: 'cart',
    component: vCart,
    props: true,
  },

  {
    path: '/admin',
    name: 'admin',
    component: vAdmin,
  },
  {
    path: '/info',
    name: 'info',
    component: vInfo,
    props: true,
  },  
  { 
    path: '*', }
  //component: NotFound } 
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
