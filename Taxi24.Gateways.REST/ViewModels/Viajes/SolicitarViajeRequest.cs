using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Gateways.REST.ViewModels.Viajes
{
    public class SolicitarViajeRequest
    {
        public long EmpresaId { get; set; }
        public long PasajeroId { get; set; }
        public double LatitudInicial { get; set; }
        public double LongitudInicial { get; set; }
    }
}
