using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Taxi24.Gateways.REST.ViewModels.Viajes
{
    public class CompletarViajeRequest
    {
        public double LongitudFinal { get; set; }
        public double LatitudFinal { get; set; }
    }
}
