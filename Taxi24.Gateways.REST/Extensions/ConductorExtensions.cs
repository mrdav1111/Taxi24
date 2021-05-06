using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Interno;

namespace Taxi24.Gateways.REST.Extensions
{
    public static class ConductorExtensions
    {
        public static ConductorDTO ObtenerDto(this ViewModels.Conductor entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ConductorDTO
            {
                EmpresaId = entity.EmpresaID,
                Disponible = entity.Disponible,
                ID = entity.ID,
                Latitud = entity.Latitud,
                Longitud = entity.Longitud,
                Nombre = entity.Nombre
            };
        }

        public static ViewModels.Conductor ObtenerEntidad(this ConductorDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new ViewModels.Conductor
            {
                EmpresaID = dto.EmpresaId,
                Disponible = dto.Disponible,
                ID = dto.ID,
                Latitud = dto.Latitud,
                Longitud = dto.Longitud,
                Nombre = dto.Nombre
            };
        }
    }
}
