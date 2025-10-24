using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;

namespace SupplierDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EntregaController : ControllerBase
    {
        private readonly IEntregaService _entregaService;

        public EntregaController(IEntregaService entregaService)
        {
            _entregaService = entregaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EntregaQueryDTO>>> GetAll()
        {
            var entrega = await _entregaService.GetAllAsync();

            if (entrega == null)
            {
                return NotFound("Entregas não encontrados");
            }

            return Ok(entrega);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] EntregaDTO model)
        {
            if (model == null)
                return BadRequest("Invalid Data");

            await _entregaService.AddAsync(model);

            return Ok();
        }
    }
}
