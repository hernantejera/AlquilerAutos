using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Pago
    {
        public int IdPago { get; set; }
        public double Monto { get; set; }
        public int IdReserva { get; set; }
        public int IdFormaDePago { get; set; }

        public virtual FormaDePago FormasDePagos { get; set; }
        public virtual Reserva Reserva { get; set; }
    }
}
