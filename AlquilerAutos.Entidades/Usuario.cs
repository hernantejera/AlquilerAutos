using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public long Dni { get; set; }
        public string Nacionalidad { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string CategoriaCarnet { get; set; }
        public DateTime FechaVencimientoCarnet { get; set; }

        public virtual List<Reserva> Reservas { get; set; } = new List<Reserva>();

    }
}
