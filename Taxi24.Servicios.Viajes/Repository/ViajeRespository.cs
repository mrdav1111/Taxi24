using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Viajes.Data;
using Taxi24.Servicios.Viajes.Entities;

namespace Taxi24.Servicios.Viajes.Repository
{
    public class ViajeRespository : IViajeRepository
    {
        private readonly ApplicationDbContext _context;

        public ViajeRespository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Viaje Actualizar(long id, Viaje viaje)
        {
            var entity = _context.Viajes.Where(v => v.ID == id).FirstOrDefault();

            if (entity != null)
            {
                entity.Final = viaje.Final;
                entity.Inicio = viaje.Inicio;
                entity.PasajeroID = viaje.PasajeroID;
                entity.PilotoID = viaje.PilotoID;

                _context.SaveChanges();
            }

            return entity;
        }

        public Viaje Crear(Viaje viaje)
        {
            var entry = _context.Viajes.Add(viaje);

            _context.SaveChanges();

            return entry.Entity;

        }

        public IEnumerable<Viaje> Lista(long empresaId)
        {
            return _context.Viajes.Where(v => v.EmpresaID == empresaId).AsNoTracking();
        }

        public Viaje ObtenerPorID(long viajeID)
        {
            return _context.Viajes.Where(v => v.ID == viajeID).AsNoTracking().FirstOrDefault();
        }
    }
}
