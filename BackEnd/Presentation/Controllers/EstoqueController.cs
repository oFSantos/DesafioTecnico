using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EstoqueController : ControllerBase
{
    private readonly IEstoqueService _estoqueService;
    private readonly IProdutoService _produtoService;

    public EstoqueController(IEstoqueService estoqueService, IProdutoService produtoService)
    {
        _estoqueService = estoqueService;
        _produtoService = produtoService;
    }

    [HttpPost("entrada")]
    [Authorize]
    public async Task<IActionResult> Entrada([FromBody] OperacaoEstoqueRequestDTO dto)
    {
        var sucesso = await _estoqueService.AdicionarProduto(dto.Codigo, dto.Quantidade);
        if (!sucesso) return BadRequest("Erro na entrada de estoque.");

        return Ok("Entrada realizada com sucesso.");
    }

    [HttpPost("saida")]
    [Authorize]
    public async Task<IActionResult> Saida([FromBody] OperacaoEstoqueRequestDTO dto)
    {
        var sucesso = await _estoqueService.RemoverProduto(dto.Codigo, dto.Quantidade);
        if (!sucesso) return BadRequest("Erro na saída de estoque.");

        return Ok("Saída realizada com sucesso.");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Listar()
    {
        var estoque = await _estoqueService.ListarEstoque();
        var response = new List<EstoqueResponseDTO>();

        foreach (var item in estoque)
        {
            var produto = await _produtoService.BuscarProduto(item.ProdutoId);
            if (produto != null)
            {
                response.Add(item.ToResponseDTO(produto));
            }
        }

        return Ok(response);
    }
}
