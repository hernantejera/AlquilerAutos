﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilerAutos.Entidades
{
    public class Vehiculo
    {   
        public int IdVehiculo { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Anio { get; set; }
        public int CantidadPasajeron { get; set; }
        public int CantidadPuertas { get; set; }
        public int IdTipoCombustible { get; set; }
        public int CapacidadCombustible { get; set; }
        public double PrecioPorDia { get; set; }
        public int CapacidadBaul { get; set; }

        public virtual TipoCombustible TipoDeCombustible { get; set; } = new TipoCombustible();

        public virtual List<Reserva> Reservas { get; set; } = new List<Reserva>();
    }
}
