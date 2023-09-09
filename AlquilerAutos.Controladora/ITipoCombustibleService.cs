using AlquilerAutos.Controladora.DTOs.TiposDeCombustibles;

namespace AlquilerAutos.Controladora
{
    public interface ITipoCombustibleService
    {
        Task<TipoCombustibleDetalleDto> Actualiza(int id, TipoCombustibleCrearDto dto);
        Task<TipoCombustibleDetalleDto> Crear(TipoCombustibleCrearDto dto);
        Task<TipoCombustibleDetalleDto> Eliminar(int id);
        Task<TipoCombustibleDetalleDto> ObtenerPorId(int id);
        Task<List<TipoCombustibleDetalleDto>> ObtenerTodo();
    }
}