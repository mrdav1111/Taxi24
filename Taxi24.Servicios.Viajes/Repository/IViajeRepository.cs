using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Viajes.Entities;

namespace Taxi24.Servicios.Viajes.Repository
{
    public interface IViajeRepository
    {
        IEnumerable<Viaje> Lista(long empresaId);
        Viaje ObtenerPorID(long viajeID);
        Viaje Crear(Viaje viaje);
        Viaje Actualizar(long id, Viaje viaje);

    }
}
