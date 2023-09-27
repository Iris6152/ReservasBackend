using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemadeReservas.EntidadesDeNegocio;
using SistemadeReservas.LogicaDeNenegocio;
using System;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SistemadeReservas.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private ReservaBL reservaBL = new ReservaBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Reserva>> Get()
        {
            return await reservaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<Reserva> Get(int id)
        {
            Reserva reserva = new Reserva();
            reserva.Id = id;
            return await reservaBL.ObtenerPorIdAsync(reserva);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Reserva reserva)
        {
            try
            {
                await reservaBL.CrearAsync(reserva);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pReserva)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strReserva = JsonSerializer.Serialize(pReserva);
            Reserva reserva = JsonSerializer.Deserialize<Reserva>(strReserva, option);
            if (reserva.Id == id)
            {
                await reservaBL.ModificarAsync(reserva);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                Reserva reserva = new Reserva();
                reserva.Id = id;
                await reservaBL.EliminarAsync(reserva);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        [AllowAnonymous]
        public async Task<List<Reserva>> Buscar([FromBody] object pReserva)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strReserva = JsonSerializer.Serialize(pReserva);
            Reserva reserva = JsonSerializer.Deserialize<Reserva>(strReserva, option);
            var reservas = await reservaBL.BuscarIncluirDepartamentosAsync(reserva);
            reservas.ForEach(s => s.Servicio = null); // Evitar la redundacia de datos
            return reservas;
        }

    }
}
