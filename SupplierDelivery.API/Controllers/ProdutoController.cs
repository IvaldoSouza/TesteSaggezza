using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;

namespace SupplierDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoQueryDTO>>> GetAll()
        {
            var produto = await _produtoService.GetAllAsync();

            if (produto == null)
            {
                return NotFound("Produtos não encontrados");
            }

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO model)
        {
            if (model == null)
                return BadRequest("Invalid Data");

            await _produtoService.AddAsync(model);

            return Ok();
        }
    }
}
