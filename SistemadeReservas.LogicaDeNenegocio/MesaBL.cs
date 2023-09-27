using SistemadeReservas.AccesoADatos;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.LogicaDeNenegocio
{
    public class MesaBL
    {
        public async Task<int> crearAsync(Mesa pMesa)
        {
            return await MesaDAL.CrearAsync(pMesa);
        }

        public async Task<int> ModificarAsync(Mesa pMesa)
        {
            return await MesaDAL.ModificarAsync(pMesa);
        }

        public async Task<int> EliminarAsync(Mesa pMesa)
        {
            return await MesaDAL.EliminarAsync(pMesa);
        }

        public async Task<Mesa> ObtenerPorIdAsync(Mesa pMesa)
        {
            return await MesaDAL.ObtenerPorIdAsync(pMesa);
        }

        public async Task<List<Mesa>> ObtenerTodosAsync()
        {
            return await MesaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Mesa>> BuscarAsync(Mesa pMesa)
        {
            return await MesaDAL.BuscarAsync(pMesa);
        }
    }
}
