using AlquilerAutos.Controladora.DTOs.Reserva;

namespace AlquilerAutos.Controladora
{
    public interface IReservaService
    {
        Task<ReservaDetalleDto> Actualizar(int id, ReservaCrearDto dto);
        Task<ReservaDetalleDto> Crear(ReservaCrearDto dto);
        Task<ReservaDetalleDto> Eliminar(int id);
        Task<ReservaDetalleDto> ObtenerPorId(int id);
        Task<List<ReservaDetalleDto>> ObtenerTodo();
    }
}