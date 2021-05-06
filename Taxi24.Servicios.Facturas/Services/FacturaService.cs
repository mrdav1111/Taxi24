using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Facturas.Repositories;
using Taxi24.Servicios.Interno;
using static Taxi24.Servicios.Interno.Facturas;

namespace Taxi24.Servicios.Facturas.Services
{
    public class FacturaService : FacturasBase
    {
        private readonly IFacturaRespository _facturaRespository;

        public FacturaService(IFacturaRespository facturaRespository)
        {
            _facturaRespository = facturaRespository;
        }
        public override async Task<ObtenerListaFacturasResponse> Lista(ObtenerListaFacturasRequest request, ServerCallContext context)
        {
            var facturas = _facturaRespository.Lista(request.EmpresaID);

            var response = new ObtenerListaFacturasResponse();

            response.Facturas.AddRange(facturas.Select(f => new FacturaDTO
            {
                Fecha = Timestamp.FromDateTime(f.Fecha.ToUniversalTime()),
                ID = f.ID,
                Monto = f.Monto,
                ViajeID = f.ViajeID,
                ViajeroID = f.ViajeroID,
                EmpresaID = f.EmpresaID
            }));

            return response;
        }
    }
}
