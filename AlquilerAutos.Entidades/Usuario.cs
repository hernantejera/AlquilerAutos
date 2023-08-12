using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Usuario
    {  
        int idVeiculo;
        string Nombre { get; set; }
        string Apellido { get; set; }
        DateTime FechaNacimiento { get; set; }
        long Dni { get; set; }
        string Nacionalidad { get; set; }
        string Telefono { get; set; }
        string Imeil { get; set; }
        string CategoriaCarnet { get; set; }
        DateTime FechaVencimientoCarnet { get; set; }


            
    }
}
