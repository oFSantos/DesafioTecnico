<template>
  <div>
    <nav>
      <router-link to="/produtos">Produtos</router-link> |
      <router-link to="/estoque">Estoque</router-link> |
      <router-link to="/movimentacao">Movimentação</router-link> |
      <a href="#" @click.prevent="logout">Sair</a>
    </nav>
    <router-view />
  </div>
</template>

<script setup>
import { useRouter } from 'vue-router';

const router = useRouter();

const logout = () => {
  localStorage.removeItem('token');
  router.push('/login');
};
</script>
