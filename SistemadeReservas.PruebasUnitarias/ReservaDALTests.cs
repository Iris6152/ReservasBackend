using Microsoft.VisualStudio.TestTools.UnitTesting;
using SistemadeReservas.AccesoADatos;
using SistemadeReservas.AccesoADatos.Tests;
using SistemadeReservas.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeReservas.AccesoADatos.Tests
{
    [TestClass()]
    public class ReservaDALTests
    {
        private static Reserva reservaInicial = new Reserva { Id = 2, IdServicio = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            reserva.IdMesa = reservaInicial.Id;
            reserva.IdServicio = reservaInicial.IdServicio;
            reserva.Cliente = "nombre del cliente";
            reserva.Telefono = "telefono del cliente";
            reserva.Fecha = "fecha de registro";
            reserva.Personas = "cuantas personas vendran";
            reserva.HorarioEntrada = "horario en el vendran";
            reserva.HorarioSalida = "hora en la que saldran";
            int result = await ReservaDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
            reservaInicial.Id = reserva.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            reserva.IdMesa = reservaInicial.Id;
            reserva.IdServicio = reservaInicial.IdServicio;
            reserva.Cliente = "nombre del cliente";
            reserva.Telefono = "telefono del cliente";
            reserva.Fecha = "fecha de registro";
            reserva.Personas = "cuantas personas vendran";
            reserva.HorarioEntrada = "horario en el vendran";
            reserva.HorarioSalida = "hora en la que saldran";
            int result = await ReservaDAL.CrearAsync(reserva);
            Assert.AreNotEqual(0, result);
            reservaInicial.Id = reserva.Id;
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            var resultReserva = await ReservaDAL.ObtenerPorIdAsync(reserva);
            Assert.AreEqual(reserva.Id, resultReserva.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultReservas = await ReservaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultReservas.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            reserva.IdMesa = reservaInicial.Id;
            reserva.IdServicio = reservaInicial.IdServicio;
            reserva.Cliente = "nombre del cliente";
            reserva.Telefono = "telefono del cliente";
            reserva.Fecha = "fecha de registro";
            reserva.Personas = "cuantas personas vendran";
            reserva.HorarioEntrada = "horario en el vendran";
            reserva.HorarioSalida = "hora en la que saldran";
            reserva.Top_Aux = 10;
            var resultReservas = await ReservaDAL.BuscarAsync(reserva);
            Assert.AreNotEqual(0, resultReservas.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirServiciosAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            reserva.IdMesa = reservaInicial.Id;
            reserva.IdServicio = reservaInicial.IdServicio;
            reserva.Cliente = "nombre del cliente";
            reserva.Telefono = "telefono del cliente";
            reserva.Fecha = "fecha de registro";
            reserva.Personas = "cuantas personas vendran";
            reserva.HorarioEntrada = "horario en el vendran";
            reserva.HorarioSalida = "hora en la que saldran"; reserva.Top_Aux = 10;
            var resultReservas = await ReservaDAL.BuscarIncluirRelacionesAsync(reserva);
            Assert.AreNotEqual(0, resultReservas.Count);
            var ultimoReserva = resultReservas.FirstOrDefault();
            Assert.IsTrue(ultimoReserva.Servicio != null && reserva.IdServicio == ultimoReserva.IdServicio);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var reserva = new Reserva();
            reserva.Id = reservaInicial.Id;
            int result = await ReservaDAL.EliminarAsync(reserva);
            Assert.AreNotEqual(0, result);
        }
    }
}