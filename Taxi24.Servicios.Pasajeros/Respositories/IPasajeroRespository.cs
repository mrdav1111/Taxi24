using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Pasajeros.Entities;

namespace Taxi24.Servicios.Pasajeros.Respositories
{
    public interface IPasajeroRespository
    {
        Pasajero Crear(Pasajero pasajero);
        Pasajero ObtenerPorId(long Id);
        IEnumerable<Pasajero> Lista(long empresaId);
        Pasajero Actualizar(long Id, Pasajero pasajero);
        Pasajero Eliminar(long Id);
    }
}
