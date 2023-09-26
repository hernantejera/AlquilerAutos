using AlquilerAutos.AccesoDatos;
using AlquilerAutos.Controladora.DTOs.Reserva;
using AlquilerAutos.Controladora.DTOs.Usuario;
using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Controladora
{
    public class ReservaService : IReservaService
    {
        private readonly AplicacionContexto _context;

        public ReservaService(AplicacionContexto Context)
        {
            _context = Context;
        }
        public async Task<List<ReservaDetalleDto>> ObtenerTodo()
        {
            var reserva = await _context.Reservas.Select(cp => new ReservaDetalleDto
            {
                Id = cp.IdReserva,
                FechaEntrada = cp.FechaEntrada,
                FechaSalida = cp.FechaSalida,
                Total = cp.Total,
                IdUsuario = cp.IdUsuario,
                IdVehiculo = cp.IdVehiculo,

            }).ToListAsync();

            return reserva;

        }
        private async Task<Reserva> IntentarObtenerPorId(int id)
        {
            var reserva = await _context.Reservas.FindAsync(id);

            if (reserva == null)
            {
                throw new Exception($"la reserva {id} no existe");
            }

            return reserva;
        }
        public async Task<ReservaDetalleDto> ObtenerPorId(int id)
        {
            var reserva = await IntentarObtenerPorId(id);

            return new ReservaDetalleDto
            {
                Id = reserva.IdReserva,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,


            };
        }
        public async Task<ReservaDetalleDto> Crear(ReservaCrearDto dto)
        {
            var reserva = new Reserva
            {
                IdReserva = dto.IdUsuario,
                FechaEntrada = dto.FechaEntrada,
                FechaSalida = dto.FechaSalida,
                Total = dto.Total,
                IdUsuario = dto.IdUsuario,
                IdVehiculo = dto.IdVehiculo,
            };


            await _context.AddAsync(reserva);

            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                Id = reserva.IdUsuario,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,




            };
        }
        public async Task<ReservaDetalleDto> Actualizar(int id, ReservaCrearDto dto)
        {
            var reserva = await IntentarObtenerPorId(id);

            reserva.IdUsuario = id;
            reserva.FechaEntrada = dto.FechaEntrada;
            reserva.FechaSalida = dto.FechaSalida;
            reserva.Total = dto.Total;
            reserva.IdVehiculo = dto.IdVehiculo;
            reserva.IdVehiculo = dto.IdVehiculo;


            _context.Update(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                Id = reserva.IdUsuario,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,


            };




        }
        public async Task<ReservaDetalleDto> Eliminar(int id)
        {
            var reserva = await IntentarObtenerPorId(id);

            _context.Remove(reserva);
            await _context.SaveChangesAsync();

            return new ReservaDetalleDto
            {
                Id = reserva.IdUsuario,
                FechaEntrada = reserva.FechaEntrada,
                FechaSalida = reserva.FechaSalida,
                Total = reserva.Total,
                IdUsuario = reserva.IdUsuario,
                IdVehiculo = reserva.IdVehiculo,

            };
        }
    }
}
