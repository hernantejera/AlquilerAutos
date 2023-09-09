using AlquilerAutos.Controladora;
using AlquilerAutos.Controladora.DTOs.FormaDePago;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormaPagoController : ControllerBase
    {
        private readonly IFormaDePagoService _formaDePagoService;

        public FormaPagoController(IFormaDePagoService formaDePagoService)
        {
            _formaDePagoService = formaDePagoService;
        }

        [HttpGet]

        public async Task<List<FormaDePagoDetalleDto>> Get()
        {
            var respuesta = await _formaDePagoService.ObtenerTodo();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<FormaDePagoDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _formaDePagoService.ObtenerPorId(id);
            return respuesta;
        }
        [HttpPost]
        public async Task<FormaDePagoDetalleDto> Post([FromBody] FormaDePagoCrearDto dto)
        {
            var respuesta = await _formaDePagoService.Crear(dto);
            return respuesta;
        }
        [HttpPut("{id}")]
        public async Task<FormaDePagoDetalleDto> Put([FromRoute] int id,
                                                     [FromBody] FormaDePagoCrearDto dto)
        {
            var respuesta = await _formaDePagoService.Actualizar(id, dto);
            return respuesta;
        }
        [HttpDelete("{id}")]
        public async Task<FormaDePagoCrearDto> Delete([FromRoute] int id)
        {
            var respuesta = await _formaDePagoService.Eliminar(id);
            return respuesta;
        }
    }
}
