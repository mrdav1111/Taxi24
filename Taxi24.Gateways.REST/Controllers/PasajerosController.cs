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
using Taxi24.Servicios.Interno;

namespace Taxi24.Gateways.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasajerosController : ControllerBase
    {
        private readonly Pasajeros.PasajerosClient _pasajerosClient;
        private readonly Conductores.ConductoresClient _conductoresClient;

        public PasajerosController(
            Pasajeros.PasajerosClient pasajerosClient,
            Conductores.ConductoresClient conductoresClient
            )
        {
            _pasajerosClient = pasajerosClient;
            _conductoresClient = conductoresClient;
        }
        [HttpGet]
        public IEnumerable<Pasajero> ObtenerListaPasajeros(long empresaId)
        {
            return _pasajerosClient.ObtenerLista(new ObtenerListaPasajerosRequest { EmpresaID = empresaId })
                .Pasajeros
                .Select(p => p.ObtenerEntidad());
        }

        [HttpGet("{id}")]
        public ActionResult<Pasajero> ObtenerPasajeroPorId(long id)
        {
            try
            {
                return _pasajerosClient.ObtenerPorId(new ObtenerPasajeroPorIdRequest { PasajeroID = id })
                    .ObtenerEntidad();
            }
            catch (RpcException e)
            {
                if (e.StatusCode == Grpc.Core.StatusCode.NotFound)
                {
                    return NotFound();
                }

                throw;
            }

        }

        [HttpGet("conductores-cercanos")]
        public IEnumerable<Conductor> ObtenerConductoresCercanos(long empresaId, double latitud, double longitud)
        {
            return _conductoresClient.ObtenerListaConductoresCercanos(new ObtenerListaConductoresCercanosRequest
            {
                Distancia = 5,
                EmpresaId = empresaId,
                Latitud = latitud,
                Longitud = longitud
            })
            .Conductores
            .OrderBy(c => CoordenadasHelper.Distancia(c.Latitud, c.Longitud, latitud, longitud))
             .Where(c => c.Disponible)
            .Take(3)
            .Select(c => c.ObtenerEntidad());
        }

    }
}
