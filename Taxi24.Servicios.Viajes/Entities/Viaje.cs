using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Servicios.Viajes.Entities
{
    public class Viaje
    {
        public long ID { get; set; }
        public long EmpresaID { get; set; }
        public long PilotoID { get; set; }
        public long PasajeroID { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Final { get; set; }
    }
}
