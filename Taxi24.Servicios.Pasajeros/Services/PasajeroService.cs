using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Pasajeros.Extensions;
using Taxi24.Servicios.Interno;
using Taxi24.Servicios.Pasajeros.Respositories;

namespace Taxi24.Servicios.Pasajeros.Services
{
    public class PasajeroService : Interno.Pasajeros.PasajerosBase
    {
        private readonly IPasajeroRespository _pasajeroRespository;

        public PasajeroService(IPasajeroRespository pasajeroRespository)
        {
            _pasajeroRespository = pasajeroRespository;
        }

        public override async Task<PasajeroDTO> Actualizar(ActualizarPasajeroRequest request, ServerCallContext context)
        {
            var entity = _pasajeroRespository.Actualizar(request.PasajeroID, request.Pasajero.ObtenerEntidad());

            return entity.ObtenerDto();
        }

        public override async Task<PasajeroDTO> Crear(CrearPasajeroRequest request, ServerCallContext context)
        {
            var entity = _pasajeroRespository.Crear(request.Pasajero.ObtenerEntidad());

            return entity.ObtenerDto();
        }

        public override async Task<PasajeroDTO> Eliminar(EliminarPasajeroRequest request, ServerCallContext context)
        {
            var entity = _pasajeroRespository.Eliminar(request.PasajeroID);
            return entity.ObtenerDto();
        }

        public override async Task<ObtenerListaPasajerosResponse> ObtenerLista(ObtenerListaPasajerosRequest request, ServerCallContext context)
        {
            var pasajeros = _pasajeroRespository.Lista(request.EmpresaID);

            ObtenerListaPasajerosResponse response = new ObtenerListaPasajerosResponse();
            response.Pasajeros.AddRange(pasajeros.Select(p => p.ObtenerDto()));

            return response;
            
        }

        public override async Task<PasajeroDTO> ObtenerPorId(ObtenerPasajeroPorIdRequest request, ServerCallContext context)
        {
            var entity = _pasajeroRespository.ObtenerPorId(request.PasajeroID);

            if (entity == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Pasajero no encontrado"));
            }

            return entity.ObtenerDto();
        }
    }
}
