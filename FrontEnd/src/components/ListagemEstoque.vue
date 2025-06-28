<template>
  <div>
    <h2>Estoque Atual</h2>
    <button @click="listarEstoque">Atualizar Estoque</button>
    <ul>
      <li v-for="item in estoque" :key="item.produtoId">
        Produto: {{ item.descricaoProduto }} ({{ item.codigoProduto }}) - Quantidade: {{ item.quantidade }}
      </li>
    </ul>

    <h2>Histórico de Movimentações</h2>
    <button @click="listarMovimentacoes(0)">Entradas</button>
    <button @click="listarMovimentacoes(1)">Saídas</button>
    <ul>
      <li v-for="mov in movimentacoes" :key="mov.id">
        Produto: {{ mov.descricaoProduto }} ({{ mov.codigoProduto }}) - 
        {{ mov.tipoMovimentacao === 0 ? 'Entrada' : 'Saída' }} - 
        Qtd: {{ mov.quantidade }} - 
        Data: {{ new Date(mov.dataMovimentacao).toLocaleString() }}
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../services/api';

const estoque = ref([]);
const movimentacoes = ref([]);

async function listarEstoque() {
  try {
    const resp = await api.get('/api/Estoque');
    estoque.value = resp.data;
  } catch (err) {
    console.error('Erro ao listar estoque', err);
  }
}

async function listarMovimentacoes(tipo) {
  try {
    const resp = await api.get(`/api/Movimentacao/${tipo}`);
    movimentacoes.value = resp.data;
  } catch (err) {
    console.error('Erro ao listar movimentações', err);
  }
}

// Carrega o estoque na montagem
onMounted(() => {
  listarEstoque();
  listarMovimentacoes(0); // Começa mostrando Entradas
});
</script>
