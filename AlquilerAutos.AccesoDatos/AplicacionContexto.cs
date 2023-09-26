using AlquilerAutos.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AlquilerAutos.AccesoDatos
{
    public class AplicacionContexto : DbContext
    {
        public AplicacionContexto(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vehiculo> Vehiculo { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<FormaDePago> FormaDePagos { get; set; }
        public DbSet<TipoCombustible> TipoCombustibles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                        .HasKey(p => p.IdUsuario);

            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Nombre)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Apellido)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.FechaNacimiento)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Dni)
                 .HasMaxLength(99_999_999)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Nacionalidad)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Telefono)
                 .HasMaxLength(15)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.Email)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.CategoriaCarnet)
                 .IsRequired();
            modelBuilder.Entity<Usuario>()
                 .Property(p => p.FechaVencimientoCarnet)
                 .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                .HasKey(p => p.IdVehiculo);

            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.Marca)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.Modelo)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.Anio)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.CantidadPasajeron)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.CantidadPuertas)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.IdTipoCombustible)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.CapacidadCombustible)
                .IsRequired();
            modelBuilder.Entity<Vehiculo>()
                .Property(p => p.PrecioPorDia)
                .IsRequired();

            modelBuilder.Entity<Vehiculo>()
                .HasOne(c => c.TipoDeCombustible)
                .WithMany(t => t.Vehiculos)
                .HasForeignKey(c => c.IdTipoCombustible);

            modelBuilder.Entity<TipoCombustible>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<TipoCombustible>()
                 .Property(p => p.Descripcion)
                .IsRequired();


            modelBuilder.Entity<Reserva>()
                .HasKey(p => p.IdReserva);
            modelBuilder.Entity<Reserva>()
                .Property(p => p.FechaEntrada)
                .IsRequired();
            modelBuilder.Entity<Reserva>()
                .Property(p => p.FechaSalida)
                .IsRequired();
            modelBuilder.Entity<Reserva>()
                .Property(p => p.Total)
                .IsRequired();
            modelBuilder.Entity<Reserva>()
                .Property(p => p.IdVehiculo)
                .IsRequired();
            modelBuilder.Entity<Reserva>()
                .Property(p => p.IdUsuario)
                .IsRequired();


            modelBuilder.Entity<Reserva>()
                        .HasOne(r => r.Usuario)
                        .WithMany(u => u.Reservas)
                        .HasForeignKey(x => x.IdUsuario);

            modelBuilder.Entity<Reserva>()
                        .HasOne(r => r.Vehiculo)
                        .WithMany(v => v.Reservas)
                        .HasForeignKey(x => x.IdVehiculo);





            modelBuilder.Entity<Pago>()
                .HasKey(P => P.IdPago);

            modelBuilder.Entity<Pago>()
                .Property(P => P.Monto)
                .IsRequired();
            modelBuilder.Entity<Pago>()
               .Property(P => P.IdReserva)
               .IsRequired();
            modelBuilder.Entity<Pago>()
               .Property(P => P.IdFormaDePago)
               .IsRequired();
            modelBuilder.Entity<Pago>()
                        .HasOne(x => x.FormasDePagos)
                        .WithMany(f => f.Pagos)
                        .HasForeignKey(x => x.IdFormaDePago);

            modelBuilder.Entity<Pago>()
                        .HasOne(r => r.Reserva)
                        .WithMany(r => r.Pagos)
                        .HasForeignKey(x => x.IdReserva);





            modelBuilder.Entity<FormaDePago>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<FormaDePago>()
                .Property(p => p.Descripcion)
                .IsRequired();











        }
    }



}
