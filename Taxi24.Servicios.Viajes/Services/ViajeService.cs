using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Interno;
using Taxi24.Servicios.Viajes.Extensions;
using Taxi24.Servicios.Viajes.MQ;
using Taxi24.Servicios.Viajes.Repository;

namespace Taxi24.Servicios.Viajes.Services
{
    public class ViajeService : Interno.Viajes.ViajesBase
    {
        private readonly IViajeRepository _viajeRepository;
        private readonly MqClient _mqClient;

        public ViajeService(IViajeRepository viajeRepository, MqClient mqClient)
        {
            _viajeRepository = viajeRepository;
            _mqClient = mqClient;
        }
        public override async Task<ViajeDTO> Actualizar(ActualizarViajeRequest request, ServerCallContext context)
        {
            var oldEntity = _viajeRepository.ObtenerPorID(request.ViajeID);
            var entity = _viajeRepository.Actualizar(request.ViajeID, request.Viaje.ObtenerEntidad());

            if (!oldEntity.Final.HasValue && entity.Final.HasValue)
            {
                _mqClient.BroadcastViajeCompletado(entity);
            }

            return entity.ObtenerDto();
        }

        public override async Task<ViajeDTO> Crear(CrearViajeRequest request, ServerCallContext context)
        {
            var entity = _viajeRepository.Crear(request.Viaje.ObtenerEntidad());

            return entity.ObtenerDto();
        }

        public override async Task<ObtenerListaResponse> ObtenerLista(ObtenerListaRequest request, ServerCallContext context)
        {
            var lista = _viajeRepository.Lista(request.EmpresaID);
            var response = new ObtenerListaResponse();

            response.Viajes.AddRange(lista.Select(v => v.ObtenerDto()));

            return response;
        }

        public override async Task<ViajeDTO> ObtenerPorID(ObtenerPorIDRequest request, ServerCallContext context)
        {
            var entity = _viajeRepository.ObtenerPorID(request.ViajeID);

            if (entity == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "No se ha encontrado el Viaje"));
            }

            return entity.ObtenerDto();
        }
    }
}
