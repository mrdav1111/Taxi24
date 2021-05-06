using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Facturas.Data;
using Taxi24.Servicios.Facturas.Entities;

namespace Taxi24.Servicios.Facturas.Repositories
{
    public class FacturaRepository : IFacturaRespository
    {
        private readonly ApplicationDbContext _context;

        public FacturaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Factura Crear(Factura factura)
        {
            _context.Facturas.Add(factura);
            _context.SaveChanges();
            return factura;
        }

        public IEnumerable<Factura> Lista(long empresaID)
        {
            return _context.Facturas.Where(f => f.EmpresaID == empresaID);
        }
    }
}
