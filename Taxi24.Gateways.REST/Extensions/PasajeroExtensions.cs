using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Interno;

namespace Taxi24.Gateways.REST.Extensions
{
    public static class PasajerosExtensions
    {
        public static PasajeroDTO ObtenerDto(this ViewModels.Pasajero entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new PasajeroDTO
            {
                EmpresaID = entity.EmpresaID,
                ID = entity.ID,
                Nombre = entity.Nombre
            };
        }

        public static ViewModels.Pasajero ObtenerEntidad(this PasajeroDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ViewModels.Pasajero
            {
                EmpresaID = dto.EmpresaID,
                ID = dto.ID,
                Nombre = dto.Nombre
            };
        }
    }
}
