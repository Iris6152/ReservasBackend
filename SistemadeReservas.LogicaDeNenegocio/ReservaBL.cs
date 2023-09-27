using SistemadeReservas.AccesoADatos;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.LogicaDeNenegocio
{
    public class ReservaBL
    {
        public async Task<int> CrearAsync(Reserva pReserva)
        {
            return await ReservaDAL.CrearAsync(pReserva);
        }

        public async Task<int> ModificarAsync(Reserva pReserva)
        {
            return await ReservaDAL.ModificarAsync(pReserva);
        }

        public async Task<int> EliminarAsync(Reserva pReserva)
        {
            return await ReservaDAL.EliminarAsync(pReserva);
        }

        public async Task<Reserva> ObtenerPorIdAsync(Reserva pReserva)
        {
            return await ReservaDAL.ObtenerPorIdAsync(pReserva);
        }

        public async Task<List<Reserva>> ObtenerTodosAsync()
        {
            return await ReservaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Reserva>> BuscarAsync(Reserva pReserva)
        {
            return await ReservaDAL.BuscarAsync(pReserva);
        }

        public async Task<List<Reserva>> BuscarIncluirDepartamentosAsync(Reserva pReserva)
        {
            return await ReservaDAL.BuscarIncluirDepartamentosAsync(pReserva);
        }
    }
}
