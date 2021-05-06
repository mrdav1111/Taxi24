using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Conductores.Entities;

namespace Taxi24.Servicios.Conductores.Repositories
{
    public interface IConductorRepository
    {
        Conductor ObtenerConductorPorID(long id);
        IEnumerable<Conductor> ObtenerListaConductores(long empresaId);
        IEnumerable<Conductor> ObtenerConductoresCercanos(double longitud, double latitud, double distancia, long empresaId);
        IEnumerable<Conductor> ObtenerConductoresDisponibles(long empresaId);
        Conductor CrearConductor(Conductor conductor);
        Conductor ActualizarConductor(long id, Conductor conductor);
        Conductor EliminarConductor(long id);
        
    }
}
