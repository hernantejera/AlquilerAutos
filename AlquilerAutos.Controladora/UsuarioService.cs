using AlquilerAutos.AccesoDatos;
using AlquilerAutos.Controladora.DTOs.FormaDePago;
using AlquilerAutos.Controladora.DTOs.Usuario;
using AlquilerAutos.Controladora.DTOs.Vehiculo;
using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Controladora
{
    public class UsuarioService : IUsuarioService
    {
        private readonly AplicacionContexto _context;

        public UsuarioService(AplicacionContexto Context)
        {
            _context = Context;
        }
        public async Task<List<UsuarioDetalleDto>> ObtenerTodo()
        {
            var usuario = await _context.Usuarios.Select(cp => new UsuarioDetalleDto
            {
                Id = cp.IdUsuario,
                Nombre = cp.Nombre,
                Apellido = cp.Apellido,
                FechaNacimiento = cp.FechaNacimiento,
                Dni = cp.Dni,
                Nacionalidad = cp.Nacionalidad,
                Telefono = cp.Telefono,
                Email = cp.Email,
                CategoriaCarnet = cp.CategoriaCarnet,
                FechaVencimientoCarnet = cp.FechaVencimientoCarnet,


            }).ToListAsync();

            return usuario;
        }
        private async Task<Usuario> IntentarObtenerPorId(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                throw new Exception($"El usuario {id} no existe");
            }

            return usuario;
        }
        public async Task<UsuarioDetalleDto> ObtenerPorId(int id)
        {
            var usuario = await IntentarObtenerPorId(id);

            return new UsuarioDetalleDto
            {
                Id = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet,

            };
        }

        public async Task<UsuarioDetalleDto> Crear(UsuarioCrearDto dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                FechaNacimiento = dto.FechaNacimiento,
                Dni = dto.Dni,
                Nacionalidad = dto.Nacionalidad,
                Telefono = dto.Telefono,
                Email = dto.Email,
                CategoriaCarnet = dto.CategoriaCarnet,
                FechaVencimientoCarnet = dto.FechaVencimientoCarnet,
            };

            var dniRepetido = await _context.Usuarios.AnyAsync(x => x.Dni == dto.Dni);
            if (dniRepetido) 
            {
                throw new Exception($"Ya existe un usuario con ese dni {dto.Dni}");
            }
            var emailRepetido = await _context.Usuarios.AnyAsync(_ => _.Email == dto.Email);
            if (emailRepetido) 
            {
                throw new Exception($"Ya existe un usuario con ese email {dto.Email}");
            }


            await _context.AddAsync(usuario);

            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet,



            };
        }
        public async Task<UsuarioDetalleDto> Actualizar(int id, UsuarioCrearDto dto)
        {
            var dniRepetido = await _context.Usuarios.AnyAsync(x => x.Dni == dto.Dni && id !=x.IdUsuario);
            if (dniRepetido)
            {
                throw new Exception($"Ya existe un usuario con ese dni {dto.Dni}");
            }
            var emailRepetido = await _context.Usuarios.AnyAsync(_ => _.Email == dto.Email);
            if (emailRepetido)
            {
                throw new Exception($"Ya existe un usuario con ese email {dto.Email}");
            } 

            var usuario = await IntentarObtenerPorId(id);

            usuario.IdUsuario = id;
            usuario.Apellido = dto.Apellido;
            usuario.FechaNacimiento = dto.FechaNacimiento;
            usuario.Dni = dto.Dni;
            usuario.Nacionalidad = dto.Nacionalidad;
            usuario.Telefono = dto.Telefono;
            usuario.Email = dto.Email;
            usuario.CategoriaCarnet = dto.CategoriaCarnet;
            usuario.FechaVencimientoCarnet = dto.FechaVencimientoCarnet;

            _context.Update(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet,


            };


        }
        public async Task<UsuarioDetalleDto> Eliminar(int id)
        {
            var usuario = await IntentarObtenerPorId(id);

            _context.Remove(usuario);
            await _context.SaveChangesAsync();

            return new UsuarioDetalleDto
            {
                Id = usuario.IdUsuario,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                FechaNacimiento = usuario.FechaNacimiento,
                Dni = usuario.Dni,
                Nacionalidad = usuario.Nacionalidad,
                Telefono = usuario.Telefono,
                Email = usuario.Email,
                CategoriaCarnet = usuario.CategoriaCarnet,
                FechaVencimientoCarnet = usuario.FechaVencimientoCarnet,

            };
        }


    }
}
