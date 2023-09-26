using AlquilerAutos.Controladora.DTOs.FormaDePago;
using AlquilerAutos.Controladora;
using Microsoft.AspNetCore.Mvc;
using AlquilerAutos.Controladora.DTOs.Vehiculo;

namespace AlquilerAutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]

        public async Task<List<VehiculoDetalleDto>> Get()
        {
            var respuesta = await _vehiculoService.ObtenerTodo();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<VehiculoDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _vehiculoService.ObtenerPorId(id);
            return respuesta;
        }
        [HttpPost]
        public async Task<VehiculoDetalleDto> Post([FromBody] VehiculoCrearDto dto)
        {
            var respuesta = await _vehiculoService.Crear(dto);
            return respuesta;
        }
        [HttpPut("{id}")]
        public async Task<VehiculoDetalleDto> Put([FromRoute] int id,
                                                     [FromBody] VehiculoCrearDto dto)
        {
            var respuesta = await _vehiculoService.Actualizar(id, dto);
            return respuesta;
        }
        [HttpDelete("{id}")]
        public async Task<VehiculoCrearDto> Delete([FromRoute] int id)
        {
            var respuesta = await _vehiculoService.Eliminar(id);
            return respuesta;
        }
    }
}
