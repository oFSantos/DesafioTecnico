using ErpProdutos.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MovimentacaoController : ControllerBase
{
    private readonly IMovimentacaoEstoqueService _movimentacaoService;
    private readonly IProdutoService _produtoService;

    public MovimentacaoController(
        IMovimentacaoEstoqueService movimentacaoService,
        IProdutoService produtoService)
    {
        _movimentacaoService = movimentacaoService;
        _produtoService = produtoService;
    }

    [HttpGet("{tipo}")]
    [Authorize]
    public async Task<IActionResult> ListarMovimentacao(TipoMovimento tipo)
    {
        var movimentacoes = await _movimentacaoService.ListarMovimentacaoEstoque(tipo);
        var response = new List<MovimentacaoEstoqueResponseDTO>();

        foreach (var mov in movimentacoes)
        {
            var produto = await _produtoService.BuscarProduto(mov.ProdutoId);
            if (produto != null)
            {
                response.Add(mov.ToResponseDTO(produto));
            }
        }

        return Ok(response);
    }
}
