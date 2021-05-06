using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Gateways.REST.ViewModels
{
    public class Pasajero
    {
        public long ID { get; set; }
        public long EmpresaID { get; set; }
        public string Nombre { get; set; }
    }
}
