using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Interno;

namespace Taxi24.Servicios.Viajes.Extensions
{
    public static class ViajeExtensions
    {
        public static Entities.Viaje ObtenerEntidad(this ViajeDTO dto)
        {
            if (dto == null)
            {
                return null;
            }

            return new Entities.Viaje
            {
                EmpresaID = dto.EmpresaID,
                Final = dto.Final == null ? null : dto.Final.ToDateTime(),
                ID = dto.ID,
                Inicio = dto.Inicio == null ? null : dto.Inicio.ToDateTime(),
                PasajeroID = dto.PasajeroID,
                PilotoID = dto.PilotoID
            };
        }

        public static ViajeDTO ObtenerDto(this Entities.Viaje viaje)
        {
            if (viaje == null)
            {
                return null;
            }

            return new ViajeDTO
            {
                EmpresaID = viaje.EmpresaID,
                Final = viaje.Final.HasValue? Timestamp.FromDateTime(viaje.Final.Value.ToUniversalTime()) : null,
                ID = viaje.ID,
                Inicio = viaje.Inicio.HasValue? Timestamp.FromDateTime(viaje.Inicio.Value.ToUniversalTime()): null,
                PasajeroID = viaje.PasajeroID,
                PilotoID = viaje.PilotoID
            };
        }
    }
}
