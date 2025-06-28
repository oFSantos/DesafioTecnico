<template>
  <div>
    <h2>Cadastrar Produto</h2>
    <form @submit.prevent="cadastrarProduto">
      <div>
        <label>Código:</label>
        <input v-model="codigo" type="text" required />
      </div>
      <div>
        <label>Descrição:</label>
        <input v-model="descricao" type="text" required />
      </div>
      <div>
        <label>Tipo:</label>
        <select v-model="tipo">
          <option :value="0">Eletrônico</option>
          <option :value="1">Eletrodoméstico</option>
          <option :value="2">Móvel</option>
        </select>
      </div>
      <div>
        <label>Valor Fornecedor:</label>
        <input v-model="valorFornecedor" type="number" step="0.01" required />
      </div>
      <button type="submit">Cadastrar</button>
    </form>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import api from '../services/api';

const codigo = ref('');
const descricao = ref('');
const tipo = ref(0);
const valorFornecedor = ref(0);

const cadastrarProduto = async () => {
  try {
    await api.post('api/Produto', {
      codigo: codigo.value,
      descricao: descricao.value,
      tipo: tipo.value,
      valorFornecedor: parseFloat(valorFornecedor.value)
    });
    alert('Produto cadastrado com sucesso!');
    // Zera os campos após cadastro
    codigo.value = '';
    descricao.value = '';
    tipo.value = 0;
    valorFornecedor.value = 0;
  } catch (error) {
    console.error('Erro ao cadastrar produto:', error);
    alert('Erro ao cadastrar produto!');
  }
};
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}

input, select {
  padding: 5px;
}

button {
  padding: 8px;
  cursor: pointer;
}
</style>
