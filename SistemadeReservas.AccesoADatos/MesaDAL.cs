using Microsoft.EntityFrameworkCore;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos
{
    public class MesaDAL
    {
        public static async Task<int> CrearAsync(Mesa pMesa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMesa);
                result = await bdContexto.SaveChangesAsync();

            }

            return result;
        }
        public static async Task<int> ModificarAsync(Mesa pMesa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var mesa = await bdContexto.Mesa.FirstOrDefaultAsync(s => s.Id == pMesa.Id);
                mesa.Tipo = pMesa.Tipo;
                bdContexto.Update(mesa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Mesa pMesa)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var mesa = await bdContexto.Mesa.FirstOrDefaultAsync(s => s.Id == pMesa.Id);
                bdContexto.Mesa.Remove(mesa);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Mesa> ObtenerPorIdAsync(Mesa pMesa)
        {
            var mesa = new Mesa();
            using (var bdContexto = new BDContexto())
            {
                mesa = await bdContexto.Mesa.FirstOrDefaultAsync(s => s.Id == pMesa.Id);
            }
            return mesa;
        }
        public static async Task<List<Mesa>> ObtenerTodosAsync()
        {
            var mesas = new List<Mesa>();
            using (var bdContexto = new BDContexto())
            {
                mesas = await bdContexto.Mesa.ToListAsync();
            }
            return mesas;
        }
        internal static IQueryable<Mesa> QuerySelect(IQueryable<Mesa> pQuery, Mesa pMesa)
        {
            if (pMesa.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMesa.Id);

            if (!string.IsNullOrWhiteSpace((string?)pMesa.Tipo))
                pQuery = pQuery.Where(s => s.Tipo.Contains(pMesa.Tipo));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pMesa.Top_Aux > 0)
                pQuery = pQuery.Take(pMesa.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Mesa>> BuscarAsync(Mesa pMesa)
        {
            var mesas = new List<Mesa>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Mesa.AsQueryable();
                select = QuerySelect(select, pMesa);
                mesas = await select.ToListAsync();
            }
            return mesas;
        }
    }
}
