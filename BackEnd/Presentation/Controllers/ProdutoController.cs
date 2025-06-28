using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoService _produtoService;

    public ProdutoController(IProdutoService produtoService)
    {
        _produtoService = produtoService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Cadastrar([FromBody] ProdutoRequestDTO dto)
    {
        var entidade = dto.ToEntity();

        var sucesso = await _produtoService.CadastrarProduto(entidade);
        if (!sucesso) return BadRequest("Erro ao cadastrar produto.");

        return Ok(entidade.ToResponseDTO());
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Atualizar(Guid id, [FromBody] ProdutoRequestDTO dto)
    {
        var produtoExistente = await _produtoService.BuscarProduto(id);
        if (produtoExistente == null) return NotFound("Produto não encontrado.");

        produtoExistente.Codigo = dto.Codigo;
        produtoExistente.Descricao = dto.Descricao;
        produtoExistente.Tipo = dto.Tipo;
        produtoExistente.ValorFornecedor = dto.ValorFornecedor;

        var sucesso = await _produtoService.AtualizarProduto(produtoExistente);
        if (!sucesso) return BadRequest("Erro ao atualizar produto.");

        return Ok(produtoExistente.ToResponseDTO());
    }

    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Deletar(Guid id)
    {
        var sucesso = await _produtoService.DeletarProduto(id);
        if (!sucesso) return NotFound("Produto não encontrado.");

        return Ok("Produto deletado com sucesso.");
    }

    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> BuscarPorId(Guid id)
    {
        var produto = await _produtoService.BuscarProduto(id);
        if (produto == null) return NotFound("Produto não encontrado.");

        return Ok(produto.ToResponseDTO());
    }

    [HttpGet("codigo/{codigo}")]
    [Authorize]
    public async Task<IActionResult> BuscarPorCodigo(string codigo)
    {
        var produto = await _produtoService.BuscarProduto(codigo);
        if (produto == null) return NotFound("Produto não encontrado.");

        return Ok(produto.ToResponseDTO());
    }

    [HttpGet("descricao/{descricao}")]
    [Authorize]
    public async Task<IActionResult> BuscarPorDescricao(string descricao)
    {
        var produtos = await _produtoService.BuscarProdutos(descricao);
        var dtos = produtos.Select(p => p.ToResponseDTO());

        return Ok(dtos);
    }
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> ListarProdutos()
    {
        var produtos = await _produtoService.ListarProdutos();
        return Ok(produtos);
    }

}
