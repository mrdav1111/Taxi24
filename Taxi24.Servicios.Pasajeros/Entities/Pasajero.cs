using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Servicios.Pasajeros.Entities
{
    public class Pasajero
    {
        public long ID { get; set; }
        public long EmpresaID { get; set; }
        public string Nombre { get; set; }
    }
}
