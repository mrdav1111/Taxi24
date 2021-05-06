using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Facturas.Entities;

namespace Taxi24.Servicios.Facturas.Repositories
{
    public interface IFacturaRespository
    {
        IEnumerable<Factura> Lista(long empresaID);
        Factura Crear(Factura factura);
    }
}
