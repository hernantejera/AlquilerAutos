using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Pago
    {
        int IdPago { get; set; }
        double Monto { get; set; }
        int IdReserva { get; set; }
        int IdFormaDePago { get; set; }    
    }
}
