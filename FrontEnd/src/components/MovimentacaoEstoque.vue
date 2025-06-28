<template>
  <div>
    <h2>Movimentação de Estoque</h2>

    <div>
      <h3>Entrada de Estoque</h3>
      <input v-model="entrada.codigo" placeholder="Código Produto" />
      <input v-model.number="entrada.quantidade" placeholder="Quantidade" type="number" />
      <button @click="entradaEstoque">Realizar Entrada</button>
    </div>

    <div>
      <h3>Saída de Estoque</h3>
      <input v-model="saida.codigo" placeholder="Código Produto" />
      <input v-model.number="saida.quantidade" placeholder="Quantidade" type="number" />
      <button @click="saidaEstoque">Realizar Saída</button>
    </div>

    <p>{{ mensagem }}</p>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import api from '../services/api';

const entrada = ref({
  codigo: '',
  quantidade: 0,
});

const saida = ref({
  codigo: '',
  quantidade: 0,
});

const mensagem = ref('');

async function entradaEstoque() {
  try {
    await api.post('/api/Estoque/entrada', entrada.value);
    mensagem.value = 'Entrada realizada com sucesso!';
    entrada.value = { codigo: '', quantidade: 0 };
  } catch (err) {
    mensagem.value = 'Erro na entrada';
    console.error(err);
  }
}

async function saidaEstoque() {
  try {
    await api.post('/api/Estoque/saida', saida.value);
    mensagem.value = 'Saída realizada com sucesso!';
    saida.value = { codigo: '', quantidade: 0 };
  } catch (err) {
    mensagem.value = 'Erro na saída';
    console.error(err);
  }
}
</script>
