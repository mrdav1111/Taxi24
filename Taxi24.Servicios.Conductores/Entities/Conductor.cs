using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Servicios.Conductores.Entities
{
    public class Conductor
    {
        public long ID { get; set; }
        public long EmpresaID { get; set; }
        public string Nombre { get; set; }
        public bool Disponible { get; set; }
        public double Longitud { get; set; }
        public double Latitud { get; set; }
    }
}
