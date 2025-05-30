💼 Desafio Técnico - Controle de Produtos e Estoque

📌 Como Participar - Fork este repositório para a sua conta do GitHub.
  Desenvolva a solução no seu fork.
  Após finalizar, abra um Pull Request (PR) para este repositório.
  Aguarde o feedback da equipe.

🎯 Objetivo - Desenvolver uma aplicação 'Windows Forms' em C# que permita:
  Cadastrar produtos com suas respectivas informações
  Realizar entradas e saídas no estoque
  Validar regras de negócio, como saldo insuficiente para saída

🧠 Funcionalidades
1. Cadastro de Produto
Formulário com campos:
  Código
  Descrição
  Tipo de Produto (ComboBox)
  Valor do Fornecedor
  Quantidade em Estoque (inicial)

3. Entrada de Estoque
  Selecionar um produto existente
  Informar quantidade a adicionar
  Atualizar ValorFornecedor

3. Saída de Estoque
  Selecionar produto
  Informar quantidade de saída
  Informar valor de venda
  Validar se há quantidade suficiente

🧪 Regras de Negócio - Não permitir saída de estoque com quantidade maior do que disponível.
  Toda saída deve registrar ValorVenda, DataMovimento e Quantidade.
  
💾 Armazenamento - Utilize o banco que desejar, Postegress, Mysql ou SQLServer.
  
🧰 Sugestão de Telas - Tela Principal (Menu com Navegação)
  Cadastro de Produto
  Movimentação de Estoque
  TabControl com "Entrada" e "Saída"
  Histórico de Movimentações

📝 Avaliação - Critérios de avaliação sugeridos:
  Organização do código
  Separação de camadas (se aplicável: Models, Services, Forms)
  Validação de dados
  Uso de eventos, controles e componentes do Windows Forms
  Boas práticas (nomes claros, comentários, tratamento de erros)
