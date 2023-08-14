using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Reserva
    {
        public int IdReserva;
        public DateTime FechaEntrada { get; set; }
        public DateTime FechaSalida { get; set; }
        public double Total { get; set; }
        public int IdVehiculo { get; set; }
        public int IdUsuario { get; set; }

    }
}
