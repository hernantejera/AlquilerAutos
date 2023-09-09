using AlquilerAutos.Controladora.DTOs.FormaDePago;

namespace AlquilerAutos.Controladora
{
    public interface IFormaDePagoService
    {
        Task<FormaDePagoDetalleDto> Actualizar(int id, FormaDePagoCrearDto dto);
        Task<FormaDePagoDetalleDto> Crear(FormaDePagoCrearDto dto);
        Task<FormaDePagoDetalleDto> Eliminar(int id);
        Task<FormaDePagoDetalleDto> ObtenerPorId(int id);
        Task<List<FormaDePagoDetalleDto>> ObtenerTodo();
    }
}