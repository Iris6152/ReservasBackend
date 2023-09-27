using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemadeReservas.AccesoADatos;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos.Tests
{
    [TestClass()]
    public class MesaDALTests
    {
        private static Mesa reservaInicial = new Mesa { Id = 2 };
        private object reserva;

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var reserva = new Mesa();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await ServicioDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
            reservaInicial.Id = reserva.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var reserva = new Mesa();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await MesaDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var reserva = new Mesa();
            reserva.Id = reservaInicial.Id;
            var resultReserva = await MesaDAL.ObtenerPorIdAsync(reserva);
            Assert.AreEqual(reserva.Id, resultReserva.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultReserva = await MesaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultReserva.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var reserva = new Mesa();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            var resultReservas = await MesaDAL.BuscarAsync(reserva);
            Assert.AreNotEqual(0, resultReservas.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var reserva = new Mesa();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await MesaDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
        }
    }
}