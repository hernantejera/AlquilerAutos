using AlquilerAutos.Controladora.DTOs.Vehiculo;
using AlquilerAutos.Controladora;
using Microsoft.AspNetCore.Mvc;
using AlquilerAutos.Controladora.DTOs.Usuario;

namespace AlquilerAutos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]

        public async Task<List<UsuarioDetalleDto>> Get()
        {
            var respuesta = await _usuarioService.ObtenerTodo();
            return respuesta;
        }

        [HttpGet("{id}")]
        public async Task<UsuarioDetalleDto> GetById([FromRoute] int id)
        {
            var respuesta = await _usuarioService.ObtenerPorId(id);
            return respuesta;
        }
        [HttpPost]
        public async Task<UsuarioDetalleDto> Post([FromBody] UsuarioCrearDto dto)
        {
            var respuesta = await _usuarioService.Crear(dto);
            return respuesta;
        }
        [HttpPut("{id}")]
        public async Task<UsuarioDetalleDto> Put([FromRoute] int id,
                                                     [FromBody] UsuarioCrearDto dto)
        {
            var respuesta = await _usuarioService.Actualizar(id, dto);
            return respuesta;
        }
        [HttpDelete("{id}")]
        public async Task<UsuarioCrearDto> Delete([FromRoute] int id)
        {
            var respuesta = await _usuarioService.Eliminar(id);
            return respuesta;
        }
    }
}
