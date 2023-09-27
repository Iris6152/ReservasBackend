using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemadeReservas.AccesoADatos;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos.Tests
{
    [TestClass()]
    public class ServicioDALTests
    {
        private static Servicio reservaInicial = new Servicio { Id = 2 };
        private object reserva;

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var reserva  = new Servicio();
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await ServicioDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
            reservaInicial.Id = reserva.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var reserva = new Servicio();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await ServicioDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var reserva = new Servicio();
            reserva.Id = reservaInicial.Id;
            var resultReserva = await ServicioDAL.ObtenerPorIdAsync(reserva);
            Assert.AreEqual(reserva.Id, resultReserva.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultReserva = await ServicioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultReserva.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var reserva = new Servicio();
            reserva.Id =reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            var resultReservas = await ServicioDAL.BuscarAsync(reserva);
            Assert.AreNotEqual(0, resultReservas.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var reserva = new Servicio();
            reserva.Id = reservaInicial.Id;
            reserva.Tipo = "nombre";
            reserva.Estado = "actvio o inactivo";
            int result = await ServicioDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
        }
    }
}