using ErpProdutos.Domain.Entities;
using ErpProdutos.Domain.Enums;

public class EstoqueService : IEstoqueService
{
    private readonly IRepositorioEstoque _estoqueRepository;
    private readonly IRepositorioProduto _produtoRepository;
    private readonly IRepositorioMovimentacaoEstoque _movimentacaoRepository;

    public EstoqueService(
        IRepositorioEstoque estoqueRepository,
        IRepositorioProduto produtoRepository,
        IRepositorioMovimentacaoEstoque movimentacaoRepository)
    {
        _estoqueRepository = estoqueRepository;
        _produtoRepository = produtoRepository;
        _movimentacaoRepository = movimentacaoRepository;
    }

    public async Task<bool> AdicionarProduto(string codigo, int qnt)
    {
        var produto = await _produtoRepository.BuscarProduto(codigo);
        if (produto == null)
            throw new Exception("Produto não encontrado.");

        var idProduto = produto.Id;

        var estoque = await _estoqueRepository.ConsultarEstoque(idProduto);
        bool resultado;

        if (estoque.Any())
        {
            // Atualiza
            var estoqueExistente = estoque.First();
            estoqueExistente.Quantidade += qnt;
            resultado = await _estoqueRepository.AtualizarEstoque(idProduto, estoqueExistente.Quantidade);
        }
        else
        {
            // Cadastra novo
            resultado = await _estoqueRepository.CadastrarProduto(idProduto, qnt);
        }

        if (resultado)
        {
            await _movimentacaoRepository.RegistrarMovimentacaoEstoque(new EntidadeMovimentacaoEstoque
            {
                ProdutoId = idProduto,
                Quantidade = qnt,
                TipoMovimentacao = TipoMovimento.Entrada,
                DataMovimentacao = DateTime.UtcNow
            });
        }

        return resultado;
    }


    public async Task<bool> RemoverProduto(string codigo, int qnt)
    {
        var produto = await _produtoRepository.BuscarProduto(codigo);
        if (produto == null)
            throw new Exception("Produto não encontrado.");


        var idProduto = produto.Id;

        var estoque = await _estoqueRepository.ConsultarEstoque(idProduto);
        if (!estoque.Any())
            throw new Exception("Produto não possui estoque.");

        var saldoAtual = estoque.First().Quantidade;
        if (saldoAtual < qnt)
            throw new Exception("Saldo insuficiente.");

        var resultado = await _estoqueRepository.DeletarProduto(idProduto, qnt);

        if (resultado)
        {
            await _movimentacaoRepository.RegistrarMovimentacaoEstoque(new EntidadeMovimentacaoEstoque
            {
                ProdutoId = idProduto,
                Quantidade = qnt,
                TipoMovimentacao = TipoMovimento.Saida,
                DataMovimentacao = DateTime.UtcNow
            });
        }

        return resultado;
    }

    public async Task<List<EntidadeEstoque>> ListarEstoque()
    {
        return await _estoqueRepository.ConsultarEstoque();
    }
}
