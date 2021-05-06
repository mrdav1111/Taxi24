using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taxi24.Servicios.Conductores.Data;
using Taxi24.Servicios.Conductores.Entities;

namespace Taxi24.Servicios.Conductores.Repositories
{
    public class ConductorRepository : IConductorRepository
    {
        private readonly ApplicationDbContext _context;

        public ConductorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public Conductor ActualizarConductor(long id, Conductor conductor)
        {
            Conductor dbConductor = _context.Conductores.Where(c => c.ID == id).FirstOrDefault();

            if (dbConductor != null)
            {
                dbConductor.Latitud = conductor.Latitud;
                dbConductor.Longitud = conductor.Longitud;
                dbConductor.Nombre = conductor.Nombre;

                _context.SaveChanges();

                return dbConductor;
            }

            throw new Exception("Conductor no encontrado");
        }

        public Conductor CrearConductor(Conductor conductor)
        {
            var entry = _context.Conductores.Add(conductor);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Conductor EliminarConductor(long id)
        {
            Conductor dbConductor = _context.Conductores.Where(c => c.ID == id).FirstOrDefault();

            if (dbConductor != null)
            {
                _context.Conductores.Remove(dbConductor);
                _context.SaveChanges();
                
            }

            return dbConductor;
        }

        public IEnumerable<Conductor> ObtenerConductoresCercanos(double longitud, double latitud, double distancia, long empresaId)
        {
  
            double distanciaKm = distancia * 0.008;
            double latitudMaxima = latitud + distanciaKm;
            double latitudMinima = latitud - distanciaKm;
            double longitudMaxima = longitud + distanciaKm;
            double longitudMinima = longitud - distanciaKm;

            IEnumerable<Conductor> conductures = _context.Conductores
                .Where(c =>
                    c.EmpresaID == empresaId
                    && c.Longitud <= longitudMaxima
                    && c.Longitud >= longitudMinima
                    && c.Latitud <= latitudMaxima
                    && c.Latitud >= latitudMinima
                );

            return conductures;
        }

        public IEnumerable<Conductor> ObtenerConductoresDisponibles(long empresaId)
        {
            return _context.Conductores.Where(c => c.Disponible && c.EmpresaID == empresaId);
        }

        public Conductor ObtenerConductorPorID(long id)
        {
            return _context.Conductores.Where(c => c.ID == id).FirstOrDefault();
        }

        public IEnumerable<Conductor> ObtenerListaConductores(long empresaId)
        {
            return _context.Conductores.Where(c => c.EmpresaID == empresaId);
        }
    }
}
