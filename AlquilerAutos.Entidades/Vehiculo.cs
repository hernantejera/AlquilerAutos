using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Vehiculo
    {   
        int IdVehiculo { get; set; }
        string Marca { get; set; }
        string Modelo { get; set; }
        int Anio { get; set; }
        int CantidadPasajeron { get; set; }
        int CantidadPuertas { get; set; }
        int IdTipoCombustible { get; set; }
        int CapasidadCombustible { get; set; }
        double PrecioPorDia { get; set; }
        int CapasidadBaul { get; set; }

    }
}
