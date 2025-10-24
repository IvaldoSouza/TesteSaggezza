using Microsoft.AspNetCore.Mvc;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;

namespace SupplierDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorDTO>>> GetAll()
        {
            var fornecedor = await _fornecedorService.GetAllAsync();

            if (fornecedor == null)
            {
                return NotFound("Fornecedores não encontrados");
            }

            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FornecedorDTO model)
        {
            if (model == null)
                return BadRequest("Invalid Data");

            await _fornecedorService.AddAsync(model);

            return Ok();
        }
    }
}
