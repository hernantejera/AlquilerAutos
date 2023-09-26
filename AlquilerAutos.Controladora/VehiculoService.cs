using AlquilerAutos.AccesoDatos;
using AlquilerAutos.Controladora.DTOs.Vehiculo;
using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlquilerAutos.Controladora
{
    public class VehiculoService : IVehiculoService
    {
        private readonly AplicacionContexto _context;

        public VehiculoService(AplicacionContexto Context)
        {
            _context = Context;
        }
        public async Task<List<VehiculoDetalleDto>> ObtenerTodo()
        {
            var vehiculo = await _context.Vehiculo.Select(cp => new VehiculoDetalleDto
            {
                Id = cp.IdVehiculo,
                Marca = cp.Marca,
                Modelo = cp.Modelo,
                Anio = cp.Anio,
                CantidadPasajeron = cp.CantidadPasajeron,
                CantidadPuertas = cp.CantidadPuertas,
                IdTipoCombustible = cp.IdTipoCombustible,
                CapacidadCombustible = cp.CapacidadCombustible,
                PrecioPorDia = cp.PrecioPorDia,
                CapacidadBaul = cp.CapacidadBaul,
            }).ToListAsync();

            return vehiculo;
        }

        private async Task<Vehiculo> IntentarObtenerPorId(int id)
        {
            var vehiculo = await _context.Vehiculo.FindAsync(id);

            if (vehiculo == null)
            {
                throw new Exception($"El vehiculo {id} no existe");
            }

            return vehiculo;
        }

        public async Task<VehiculoDetalleDto> ObtenerPorId(int id)
        {
            var vehiculo = await IntentarObtenerPorId(id);

            return new VehiculoDetalleDto
            {
                Id = vehiculo.IdVehiculo,
                Marca = vehiculo.Marca,
                Modelo = vehiculo.Modelo,
                Anio = vehiculo.Anio,
                CantidadPasajeron = vehiculo.CantidadPasajeron,
                CantidadPuertas = vehiculo.CantidadPuertas,
                IdTipoCombustible = vehiculo.IdTipoCombustible,
                CapacidadCombustible = vehiculo.CapacidadCombustible,
                PrecioPorDia = vehiculo.PrecioPorDia,
                CapacidadBaul = vehiculo.CapacidadBaul,
            };
        }

        public async Task<VehiculoDetalleDto> Crear(VehiculoCrearDto dto)
        {
            var entidad = new Vehiculo
            {
                Marca = dto.Marca,
                Modelo = dto.Modelo,
                Anio = dto.Anio,
                CantidadPasajeron = dto.CantidadPasajeron,
                CantidadPuertas = dto.CantidadPuertas,
                IdTipoCombustible = dto.IdTipoCombustible,
                CapacidadCombustible = dto.CapacidadCombustible,
                PrecioPorDia = dto.PrecioPorDia,
                CapacidadBaul = dto.CapacidadBaul,
            };


            await _context.AddAsync(entidad);

            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = entidad.IdVehiculo,
                Marca = entidad.Marca,
                Modelo = entidad.Modelo,
                Anio = entidad.Anio,
                CantidadPasajeron = entidad.CantidadPasajeron,
                CantidadPuertas = entidad.CantidadPuertas,
                IdTipoCombustible = entidad.IdTipoCombustible,
                CapacidadCombustible = entidad.CapacidadCombustible,
                PrecioPorDia = entidad.PrecioPorDia,
                CapacidadBaul = entidad.CapacidadBaul,


            };
        }
        public async Task<VehiculoDetalleDto> Actualizar(int id, VehiculoCrearDto dto)
        {
            var entidad = await IntentarObtenerPorId(id);

            entidad.Marca = dto.Marca;
            entidad.Modelo = dto.Modelo;
            entidad.Anio = dto.Anio;
            entidad.CantidadPasajeron = dto.CantidadPasajeron;
            entidad.CantidadPuertas = dto.CantidadPuertas;
            entidad.IdTipoCombustible = dto.IdTipoCombustible;
            entidad.CapacidadCombustible = dto.CapacidadCombustible;
            entidad.PrecioPorDia = dto.PrecioPorDia;
            entidad.CapacidadBaul = dto.CapacidadBaul;

            _context.Update(entidad);
            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = entidad.IdVehiculo,
                Marca = entidad.Marca,
                Modelo = entidad.Modelo,
                Anio = entidad.Anio,
                CantidadPasajeron = entidad.CantidadPasajeron,
                CantidadPuertas = entidad.CantidadPuertas,
                IdTipoCombustible = entidad.IdTipoCombustible,
                CapacidadCombustible = entidad.CapacidadCombustible,
                PrecioPorDia = entidad.PrecioPorDia,
                CapacidadBaul = entidad.CapacidadBaul,


            };


        }
        public async Task<VehiculoDetalleDto> Eliminar(int id)
        {
            var entidad = await IntentarObtenerPorId(id);

            _context.Remove(entidad);
            await _context.SaveChangesAsync();

            return new VehiculoDetalleDto
            {
                Id = entidad.IdVehiculo,
                Marca = entidad.Marca,
                Modelo = entidad.Modelo,
                Anio = entidad.Anio,
                CantidadPasajeron = entidad.CantidadPasajeron,
                CantidadPuertas = entidad.CantidadPuertas,
                IdTipoCombustible = entidad.IdTipoCombustible,
                CapacidadCombustible = entidad.CapacidadCombustible,
                PrecioPorDia = entidad.PrecioPorDia,
                CapacidadBaul = entidad.CapacidadBaul,


            };
        }
    }
}
