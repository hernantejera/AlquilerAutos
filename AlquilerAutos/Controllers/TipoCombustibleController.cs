using AlquilerAutos.Controladora;
using AlquilerAutos.Controladora.DTOs.TiposDeCombustibles;
using Microsoft.AspNetCore.Mvc;

namespace AlquilerAutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoCombustibleController : ControllerBase
    {
        private readonly ITipoCombustibleService _tipoCombustibleService;

        public TipoCombustibleController(ITipoCombustibleService tipoCombustibleService)
        {
            _tipoCombustibleService = tipoCombustibleService;
        }

        [HttpGet]
        public async Task<List<TipoCombustibleDetalleDto>> Get()
        {
            var respuesta = await _tipoCombustibleService.ObtenerTodo();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<TipoCombustibleDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _tipoCombustibleService.ObtenerPorId(id);
            return respuesta;
        }

        [HttpPost]
        public async Task<TipoCombustibleDetalleDto> Post([FromBody] TipoCombustibleCrearDto dto)
        {
            var respuesta = await _tipoCombustibleService.Crear(dto);
            return respuesta;
        }

        [HttpPut("{id}")]
        public async Task<TipoCombustibleDetalleDto> Put([FromRoute] int id,
                                                     [FromBody] TipoCombustibleCrearDto dto)
        {
            var respuesta = await _tipoCombustibleService.Actualiza(id, dto);
            return respuesta;
        }

        [HttpDelete("{id}")]
        public async Task<TipoCombustibleCrearDto> Delete([FromRoute] int id)
        {
            var respuesta = await _tipoCombustibleService.Eliminar(id);
            return respuesta;
        }


    }
}
