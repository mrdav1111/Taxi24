using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Gateways.REST.Extensions;
using Taxi24.Gateways.REST.Helpers;
using Taxi24.Gateways.REST.ViewModels;
using Taxi24.Gateways.REST.ViewModels.Viajes;
using Taxi24.Servicios.Interno;
using static Taxi24.Servicios.Interno.Conductores;
using static Taxi24.Servicios.Interno.Viajes;

namespace Taxi24.Gateways.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajesController : ControllerBase
    {
        private readonly ViajesClient _viajesClient;
        private readonly ConductoresClient _conductoresClient;

        public ViajesController(ViajesClient viajesClient, ConductoresClient conductoresClient)
        {
            _viajesClient = viajesClient;
            _conductoresClient = conductoresClient;
        }

        [HttpGet]
        public IEnumerable<Viaje> ObtenerListaViajes(long empresaID)
        {
            return _viajesClient.ObtenerLista(new Servicios.Interno.ObtenerListaRequest { EmpresaID = empresaID })
                .Viajes
                .Select(v => v.ObtenerEntidad());
        }

        [HttpPost]
        public ActionResult<Viaje> SolicitarViaje([FromBody] SolicitarViajeRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var conductorCercano = _conductoresClient.ObtenerListaConductoresCercanos(new ObtenerListaConductoresCercanosRequest
            {
                Distancia = 5,
                EmpresaId = request.EmpresaId,
                Latitud = request.LatitudInicial,
                Longitud = request.LongitudInicial
            })
            .Conductores
            .Where(c => c.Disponible)
            .OrderBy(c => CoordenadasHelper.Distancia(c.Latitud, c.Longitud, request.LatitudInicial, request.LongitudInicial))
            .Select(c => c.ObtenerEntidad())
            .FirstOrDefault();

            if (conductorCercano == null)
            {
                return NotFound("No se ha podido encontrar un conductor cercano.");
            }

            var solicitudDeViaje = _viajesClient.Crear(new Servicios.Interno.CrearViajeRequest
            {
                Viaje = new Servicios.Interno.ViajeDTO
                {
                    EmpresaID = request.EmpresaId,
                    Inicio = Timestamp.FromDateTime(DateTime.UtcNow),
                    PasajeroID = request.PasajeroId,
                    PilotoID = conductorCercano.ID
                }
            });

            conductorCercano.Disponible = false;

            _conductoresClient.ActualizarConductor(new ActualizarConductorRequest { ID = conductorCercano.ID, Conductor = conductorCercano.ObtenerDto() });

            return solicitudDeViaje.ObtenerEntidad();
        }

        [HttpPost("completar/{id}")]
        public ActionResult<Viaje> CompletarViaje(long id, [FromBody] CompletarViajeRequest request)
        {

            if (request == null)
            {
                return BadRequest();
            }
            try
            {
                var viaje = _viajesClient.ObtenerPorID(new ObtenerPorIDRequest { ViajeID = id });
                var conductor = _conductoresClient.ObtenerConductorPorID(new ObtenerConductorPorIDRequest { ID = viaje.PilotoID });

                viaje.Final = Timestamp.FromDateTime(DateTime.UtcNow);

                viaje = _viajesClient.Actualizar(new ActualizarViajeRequest { ViajeID = id, Viaje = viaje });

                conductor.Disponible = true;
                _conductoresClient.ActualizarConductor(new ActualizarConductorRequest { ID = viaje.PilotoID, Conductor = conductor });

                return viaje.ObtenerEntidad();

            }
            catch (RpcException e)
            {
                if (e.StatusCode == Grpc.Core.StatusCode.NotFound)
                {
                    return NotFound(e.Message);
                }

                throw;
            }

        }
    }
}
