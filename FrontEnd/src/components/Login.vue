<template>
  <div>
    <h2>Login</h2>
    <form @submit.prevent="login">
      <div>
        <label>Usuário:</label>
        <input v-model="usuario" required />
      </div>
      <div>
        <label>Senha:</label>
        <input v-model="senha" type="password" required />
      </div>
      <button type="submit">Entrar</button>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import axios from 'axios';
import { useRouter } from 'vue-router';

const usuario = ref('');
const senha = ref('');
const router = useRouter();

const login = async () => {
  try {
    const resposta = await axios.post('http://localhost:5042/Autentication/login', {
      username: usuario.value,
      password: senha.value
    });

    localStorage.setItem('token', resposta.data.token);
    router.push('/produtos');
  } catch (error) {
    alert('Usuário ou senha inválidos');
    console.error(error);
  }
};
</script>
