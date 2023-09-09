using AlquilerAutos.AccesoDatos;
using AlquilerAutos.Controladora.DTOs.FormaDePago;
using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlquilerAutos.Controladora
{
    public class FormaDePagoService : IFormaDePagoService
    {
        private readonly AplicacionContexto _context;

        public FormaDePagoService(AplicacionContexto Context)
        {
            _context = Context;
        }

        public async Task<List<FormaDePagoDetalleDto>> ObtenerTodo()
        {
            var formaPago = await _context.FormaDePagos.Select(cp => new FormaDePagoDetalleDto
            {
                Id = cp.Id,
                Descripcion = cp.Descripcion,
            }).ToListAsync();

            return formaPago;
        }

        public async Task<FormaDePagoDetalleDto> ObtenerPorId(int id)
        {
            var formaPago = await IntentarObtenerPorId(id);

            return new FormaDePagoDetalleDto
            {
                Id = formaPago.Id,
                Descripcion = formaPago.Descripcion,
            };
        }

        private async Task<FormaDePago> IntentarObtenerPorId(int id)
        {
            var formaPago = await _context.FormaDePagos.FindAsync(id);

            if (formaPago == null)
            {
                throw new Exception($"La forma de pago{id} no existe");
            }

            return formaPago;
        }

        public async Task<FormaDePagoDetalleDto> Crear(FormaDePagoCrearDto dto)
        {
            //Creo la entidad que voy a instertar en la base de datos mapeando los datos que tengo en el DTO
            var entidad = new FormaDePago
            {
                Descripcion = dto.Descripcion,
            };

            // me fijo si ya existe la descripcion en la base de datos
            var existeDescripcion = await _context.FormaDePagos
                                                  .AnyAsync(x => x.Descripcion.ToLower() == dto.Descripcion.ToLower());

            // si existe voy a tirar una excepcion ya que no permitimos descripciones duplicadas
            if (existeDescripcion)
                throw new Exception($"La descripcion{dto.Descripcion} ya xiste , usa otra");

            // llamo al contexto para crear la query que se va a usar para crear el nuevo registro en la base de datos
            await _context.AddAsync(entidad);

            // Ejecuto la query que cree anteriormente
            await _context.SaveChangesAsync();

            //Mapeo los datos de la entidad al DTO que voy a devolver
            return new FormaDePagoDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
            };

        }

        public async Task<FormaDePagoDetalleDto> Actualizar(int id, FormaDePagoCrearDto dto)
        {
            var entidad = await IntentarObtenerPorId(id);

            entidad.Descripcion = dto.Descripcion;
            _context.Update(entidad);
            await _context.SaveChangesAsync();

            return new FormaDePagoDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion,
            };
        }

        public async Task<FormaDePagoDetalleDto> Eliminar(int id)
        {
            var entidad = await IntentarObtenerPorId(id);

            _context.Remove(entidad);
            await _context.SaveChangesAsync();

            return new FormaDePagoDetalleDto
            {
                Id = entidad.Id,
                Descripcion = entidad.Descripcion
            };
        }
    }
}
