import { createRouter, createWebHistory } from 'vue-router';
import Login from '../components/Login.vue';
import ProdutosView from '../views/ProdutosView.vue';
import EstoqueView from '../views/EstoqueView.vue';
import MovimentacaoView from '../views/MovimentacaoView.vue';

const routes = [
  { path: '/', redirect: '/produtos' },
  { path: '/login', component: Login },
  { path: '/produtos', component: ProdutosView, meta: { requiresAuth: true } },
  { path: '/estoque', component: EstoqueView, meta: { requiresAuth: true } },
  { path: '/movimentacao', component: MovimentacaoView, meta: { requiresAuth: true } }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token');
  if (to.meta.requiresAuth && !token) {
    next('/login');
  } else {
    next();
  }
});

export default router;
