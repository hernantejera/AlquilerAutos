using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Reserva
    {   
        int IdReserva;
        DateTime FechaEntrada { get; set; }
        DateTime FechaSalida { get; set; }
        double Total { get; set; }
        int IdVehiculo { get; set; }
        int IdUsuario { get; set; }

    }
}
