using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemadeReservas.EntidadesDeNegocio;

namespace SistemadeReservas.AccesoADatos
{
    public class ServicioDAL
    {
        public static async Task<int> CrearAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pServicio);
                result = await bdContexto.SaveChangesAsync();

            }

            return result;
        }
        public static async Task<int> ModificarAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                servicio.Tipo = pServicio.Tipo;
                servicio.Estado = pServicio.Estado;
                bdContexto.Update(servicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                bdContexto.Servicio.Remove(servicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Servicio> ObtenerPorIdAsync(Servicio pServicio)
        {
            var servicio = new Servicio();
            using (var bdContexto = new BDContexto())
            {
                servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
            }
            return servicio;
        }
        public static async Task<List<Servicio>> ObtenerTodosAsync()
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                servicios = await bdContexto.Servicio.ToListAsync();
            }
            return servicios;
        }
        internal static IQueryable<Servicio> QuerySelect(IQueryable<Servicio> pQuery, Servicio pServicio)
        {
            if (pServicio.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pServicio.Id);

            if (!string.IsNullOrWhiteSpace(pServicio.Tipo))
                pQuery = pQuery.Where(s => s.Tipo.Contains(pServicio.Tipo));

            if (!string.IsNullOrWhiteSpace(pServicio.Estado))
                pQuery = pQuery.Where(s => s.Estado.Contains(pServicio.Estado));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pServicio.Top_Aux > 0)
                pQuery = pQuery.Take(pServicio.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Servicio>> BuscarAsync(Servicio pServicio)
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Servicio.AsQueryable();
                select = QuerySelect(select, pServicio);
                servicios = await select.ToListAsync();
            }
            return servicios;
        }

        public static Task<int> CrearAsync(object reserva)
        {
            throw new NotImplementedException();
        }
    }

}
