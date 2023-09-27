using Microsoft.EntityFrameworkCore;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos
{
    //reserva va con la de municipio//
    public class ReservaDAL
    {
        public static async Task<int> CrearAsync(Reserva pReserva)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pReserva);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Reserva pReserva)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var reserva = await bdContexto.Reserva.FirstOrDefaultAsync(s => s.Id == pReserva.Id);
                reserva.Id = pReserva.Id;
                reserva.IdMesa = pReserva.IdMesa;
                reserva.IdServicio = pReserva.IdServicio;
                reserva.Cliente = pReserva.Cliente;
                reserva.Telefono = pReserva.Telefono;
                reserva.Fecha = pReserva.Fecha;
                reserva.Personas = pReserva.Personas;
                reserva.HorarioEntrada = pReserva.HorarioEntrada;
                reserva.HorarioSalida = pReserva.HorarioSalida;
                bdContexto.Update(reserva);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Reserva pReserva)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var reserva = await bdContexto.Reserva.FirstOrDefaultAsync(s => s.Id == pReserva.Id);
                bdContexto.Reserva.Remove(reserva);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Reserva> ObtenerPorIdAsync(Reserva pReserva)
        {
            var reserva = new Reserva();
            using (var bdContexto = new BDContexto())
            {
                reserva = await bdContexto.Reserva.FirstOrDefaultAsync(s => s.Id == pReserva.Id);
            }
            return reserva;
        }
        public static async Task<List<Reserva>> ObtenerTodosAsync()
        {
            var reservas = new List<Reserva>();
            using (var bdContexto = new BDContexto())
            {
                reservas = await bdContexto.Reserva.ToListAsync();
            }
            return reservas;
        }
        internal static IQueryable<Reserva> QuerySelect(IQueryable<Reserva> pQuery, Reserva pReserva)
        {
            if (pReserva.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pReserva.Id);

            if (pReserva.IdMesa > 0)
                pQuery = pQuery.Where(s => s.IdMesa == pReserva.IdMesa);

            if (pReserva.IdServicio > 0)
                pQuery = pQuery.Where(s => s.IdServicio == pReserva.IdServicio);

            if (pReserva.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pReserva.Id);


            if (!string.IsNullOrWhiteSpace(pReserva.Cliente))
                pQuery = pQuery.Where(s => s.Cliente.Contains(pReserva.Cliente));
            if (!string.IsNullOrWhiteSpace(pReserva.Telefono))
                pQuery = pQuery.Where(s => s.Telefono.Contains(pReserva.Telefono));
            if (!string.IsNullOrWhiteSpace(pReserva.Personas))
                pQuery = pQuery.Where(s => s.Personas.Contains(pReserva.Personas));
            if (!string.IsNullOrWhiteSpace(pReserva.HorarioEntrada))
                pQuery = pQuery.Where(s => s.HorarioEntrada.Contains(pReserva.HorarioEntrada));
            if (!string.IsNullOrWhiteSpace(pReserva.HorarioSalida))
                pQuery = pQuery.Where(s => s.HorarioSalida.Contains(pReserva.HorarioSalida));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pReserva.Top_Aux > 0)
                pQuery = pQuery.Take(pReserva.Top_Aux).AsQueryable();
            return pQuery;
        }

        public static async Task<List<Reserva>> BuscarAsync(Reserva pReserva)
        {
            var reservas = new List<Reserva>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Reserva.AsQueryable();
                select = QuerySelect(select, pReserva);
                reservas = await select.ToListAsync();
            }
            return reservas;
        }
        // solo esto va arreglar//
        public static async Task<List<Reserva>> BuscarIncluirRelacionesAsync(Reserva pReserva)
        {
            var reservas = new List<Reserva>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Reserva.AsQueryable();
                select = QuerySelect(select, pReserva).Include(s => s.Mesa).Include(s => s.Servicio).AsQueryable();
                reservas = await select.ToListAsync();
            }
            return reservas;
        }
    }
}

