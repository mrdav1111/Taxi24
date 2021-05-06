using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Pasajeros.Data;
using Taxi24.Servicios.Pasajeros.Entities;

namespace Taxi24.Servicios.Pasajeros.Respositories
{
    public class PasajeroRepository : IPasajeroRespository
    {
        private readonly ApplicationDbContext _context;

        public PasajeroRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Pasajero Actualizar(long Id, Pasajero pasajero)
        {
            Pasajero dbPasajero = _context.Pasajeros.Where(p => p.ID == Id).FirstOrDefault();

            if (dbPasajero != null)
            {
                dbPasajero.EmpresaID = pasajero.EmpresaID;
                dbPasajero.Nombre = pasajero.Nombre;

                _context.SaveChanges();
            }

            return dbPasajero;
        }

        public Pasajero Eliminar(long Id)
        {
            Pasajero dbPasajero = _context.Pasajeros.Where(p => p.ID == Id).FirstOrDefault();

            if (dbPasajero != null)
            {
                _context.Pasajeros.Remove(dbPasajero);

                _context.SaveChanges();
            }

            return dbPasajero;
        }

        public Pasajero Crear(Pasajero pasajero)
        {
            EntityEntry<Pasajero> dbPasajero = _context.Pasajeros.Add(pasajero);

            _context.SaveChanges();

            return dbPasajero.Entity;
        }

        public IEnumerable<Pasajero> Lista(long empresaId)
        {
            return _context.Pasajeros.Where(p => p.EmpresaID == empresaId);
        }

        public Pasajero ObtenerPorId(long Id)
        {
            return _context.Pasajeros.Where(p => p.ID == Id).FirstOrDefault();
        }
    }
}
