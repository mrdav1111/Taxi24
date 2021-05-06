using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Servicios.Facturas.Entities
{
    public class Factura
    {
        public long ID { get; set; }
        public long EmpresaID { get; set; }
        public DateTime Fecha { get; set; }
        public long ViajeID { get; set; }
        public long ConductorID { get; set; }
        public long ViajeroID { get; set;}
        public double Monto { get; set; }
    }
}
