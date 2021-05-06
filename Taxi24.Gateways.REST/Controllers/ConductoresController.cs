using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Taxi24.Gateways.REST.ViewModels;
using Taxi24.Servicios.Interno;
using Taxi24.Gateways.REST.Extensions;

namespace Taxi24.Gateways.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductoresController : ControllerBase
    {
        private readonly Conductores.ConductoresClient _conductoresClient;

        public ConductoresController(Conductores.ConductoresClient conductoresClient)
        {
            _conductoresClient = conductoresClient;
        }

        [HttpGet]
        public IEnumerable<Conductor> ObtenerConductores(long empresaId)
        {
            return _conductoresClient.ObtenerListaConductores(new ObtenerListaConductoresRequest { EmpresaId = empresaId })
                .Conductores
                .Select(c => c.ObtenerEntidad());
        }

        [HttpGet("disponibles")]
        public IEnumerable<Conductor> ObtenerConductoresDisponibles(long empresaId)
        {
            return _conductoresClient.ObtenerListaConductoresDisponibles(new ObtenerListaConductoresDisponiblesRequest
            {
                EmpresaId = empresaId
            })
                .Conductores
                .Select(c => c.ObtenerEntidad());
        }
        
        /// <summary>
        /// Obtiene una lista de los conductures en un radio de 3 km de una ubicacion determinada.
        /// </summary>
        /// <param name="empresaId"></param>
        /// <param name="latitud"></param>
        /// <param name="longitud"></param>
        /// <returns></returns>
        [HttpGet("cercanos")]
        public IEnumerable<Conductor> ObtenerConductoresCercanos(long empresaId, double latitud, double longitud)
        {
            return _conductoresClient.ObtenerListaConductoresCercanos(new ObtenerListaConductoresCercanosRequest
            {
                Distancia = 3,
                EmpresaId = empresaId,
                Latitud = latitud,
                Longitud = longitud
            })
                .Conductores
                .Select(c => c.ObtenerEntidad());
        }

        [HttpGet("{id}")]
        public ActionResult<Conductor> ObtenerConductorPorId(long id)
        {
            try
            {
                return _conductoresClient.ObtenerConductorPorID(new ObtenerConductorPorIDRequest { ID = id }).ObtenerEntidad();
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

    }
}
