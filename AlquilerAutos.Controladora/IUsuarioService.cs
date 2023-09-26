using AlquilerAutos.Controladora.DTOs.Usuario;

namespace AlquilerAutos.Controladora
{
    public interface IUsuarioService
    {
        Task<UsuarioDetalleDto> Actualizar(int id, UsuarioCrearDto dto);
        Task<UsuarioDetalleDto> Crear(UsuarioCrearDto dto);
        Task<UsuarioDetalleDto> Eliminar(int id);
        Task<UsuarioDetalleDto> ObtenerPorId(int id);
        Task<List<UsuarioDetalleDto>> ObtenerTodo();
    }
}