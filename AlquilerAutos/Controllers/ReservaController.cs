using AlquilerAutos.Controladora.DTOs.Usuario;
using AlquilerAutos.Controladora;
using Microsoft.AspNetCore.Mvc;
using AlquilerAutos.Controladora.DTOs.Reserva;

namespace AlquilerAutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ReservaController:ControllerBase
    {
        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            _reservaService = reservaService;
        }

        [HttpGet]

        public async Task<List<ReservaDetalleDto>> Get()
        {
            var respuesta = await _reservaService.ObtenerTodo();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<ReservaDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _reservaService.ObtenerPorId(id);
            return respuesta;
        }
        [HttpPost]
        public async Task<ReservaDetalleDto> Post([FromBody] ReservaCrearDto dto)
        {
            var respuesta = await _reservaService.Crear(dto);
            return respuesta;
        }
        [HttpPut("{id}")]
        public async Task<ReservaDetalleDto> Put([FromRoute] int id,
                                                     [FromBody] ReservaCrearDto dto)
        {
            var respuesta = await _reservaService.Actualizar(id, dto);
            return respuesta;
        }
        [HttpDelete("{id}")]
        public async Task<ReservaCrearDto> Delete([FromRoute] int id)
        {
            var respuesta = await _reservaService.Eliminar(id);
            return respuesta;
        }


    }
}
