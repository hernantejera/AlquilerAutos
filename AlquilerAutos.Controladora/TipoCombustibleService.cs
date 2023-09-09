using AlquilerAutos.AccesoDatos;
using AlquilerAutos.Controladora.DTOs.FormaDePago;
using AlquilerAutos.Controladora.DTOs.TiposDeCombustibles;
using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlquilerAutos.Controladora
{
    public class TipoCombustibleService : ITipoCombustibleService
    {
        private readonly AplicacionContexto _context;

        public TipoCombustibleService(AplicacionContexto Context)
        {
            _context = Context;
        }
        public async Task<List<TipoCombustibleDetalleDto>> ObtenerTodo()
        {
            var tipoCombustible = await _context.TipoCombustibles.Select(cp => new TipoCombustibleDetalleDto
            {
                Id = cp.Id,
                Descripcion = cp.Descripcion,
            }).ToListAsync();

            return tipoCombustible;
        }

        private async Task<TipoCombustible> IntentarObtenerPorId(int id)
        {
            var tipoCombustible = await _context.TipoCombustibles.FindAsync(id);

            if (tipoCombustible == null)
            {
                throw new Exception($"El tipo de combustible {id} no existe");
            }

            return tipoCombustible;
        }

        public async Task<TipoCombustibleDetalleDto> ObtenerPorId(int id)
        {
            var tipoCombustible = await IntentarObtenerPorId(id);

            return new TipoCombustibleDetalleDto
            {
                Id = tipoCombustible.Id,
                Descripcion = tipoCombustible.Descripcion,
            };
        }

        public async Task<TipoCombustibleDetalleDto> Crear(TipoCombustibleCrearDto dto)
        {
            var entidad = new TipoCombustible
            {
                Descripcion = dto.Descripcion,
            };

            var existeDescripcion = await _context.TipoCombustibles
                                                  .AnyAsync(x => x.Descripcion.ToLower() == dto.Descripcion.ToLower());

            if (existeDescripcion)
                throw new Exception($"La descripcion{dto.Descripcion} ya xiste , usa otra");

            await _context.AddAsync(entidad);

            await _context.SaveChangesAsync();

            return new TipoCombustibleDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
            };
        }
        public async Task<TipoCombustibleDetalleDto> Actualiza(int id, TipoCombustibleCrearDto dto)
        {
            var entidad = await IntentarObtenerPorId(id);

            entidad.Descripcion = dto.Descripcion;
            _context.Update(entidad);
            await _context.SaveChangesAsync();

            return new TipoCombustibleDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
            };


        }
        public async Task<TipoCombustibleDetalleDto> Eliminar(int id)
        {
            var entidad = await IntentarObtenerPorId(id);

            _context.Remove(entidad);
            await _context.SaveChangesAsync();

            return new TipoCombustibleDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion
            };
        }

    }
}
