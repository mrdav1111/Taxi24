using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Conductores.Extensions;
using Taxi24.Servicios.Conductores.Repositories;
using Taxi24.Servicios.Interno;

namespace Taxi24.Servicios.Conductores.Services
{
    public class ConductoresService : Interno.Conductores.ConductoresBase
    {
        private readonly IConductorRepository _conductorRepository;

        public ConductoresService(IConductorRepository conductorRepository)
        {
            _conductorRepository = conductorRepository;
        }

        public override async Task<ConductorDTO> ActualizarConductor(ActualizarConductorRequest request, ServerCallContext context)
        {
           var entity = _conductorRepository.ActualizarConductor(request.ID, request.Conductor.ObtenerEntidad());

            return entity.ObtenerDto();
        }

        public override async Task<ConductorDTO> CrearConductor(ConductorDTO request, ServerCallContext context)
        {
            var entity = _conductorRepository.CrearConductor(request.ObtenerEntidad());

            return entity.ObtenerDto();
        }

        public override async Task<ConductorDTO> EliminarConductor(EliminarConductorRequest request, ServerCallContext context)
        {
            var entity = _conductorRepository.EliminarConductor(request.ID);

            return entity.ObtenerDto();
        }

        public override async Task<ConductorDTO> ObtenerConductorPorID(ObtenerConductorPorIDRequest request, ServerCallContext context)
        {
            var entity = _conductorRepository.ObtenerConductorPorID(request.ID);

            if (entity == null)
            {
                throw new RpcException(new Status(StatusCode.NotFound, "Conductor no encontrado"));
            }

            return entity.ObtenerDto();
        }

        public override async Task<ListaConductoresResponse> ObtenerListaConductores(ObtenerListaConductoresRequest request, ServerCallContext context)
        {
            var response = new ListaConductoresResponse();
            var listaConductores = _conductorRepository.ObtenerListaConductores(request.EmpresaId);

            response.Conductores.AddRange(listaConductores.Select(c => c.ObtenerDto()));

            return response;
        }

        public override async Task<ListaConductoresResponse> ObtenerListaConductoresCercanos(ObtenerListaConductoresCercanosRequest request, ServerCallContext context)
        {
            var conductores = _conductorRepository.ObtenerConductoresCercanos(request.Longitud, request.Latitud, request.Distancia, request.EmpresaId);

            var response = new ListaConductoresResponse();
            response.Conductores.AddRange(conductores.Select(c => c.ObtenerDto()));

            return response;
        }

        public override async Task<ListaConductoresResponse> ObtenerListaConductoresDisponibles(ObtenerListaConductoresDisponiblesRequest request, ServerCallContext context)
        {
            var conductores = _conductorRepository.ObtenerConductoresDisponibles(request.EmpresaId);

            var response = new ListaConductoresResponse();
            response.Conductores.AddRange(conductores.Select(c => c.ObtenerDto()));

            return response;
        }
    }
}
