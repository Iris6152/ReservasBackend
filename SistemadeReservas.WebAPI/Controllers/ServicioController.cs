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
    public class ServicioController : ControllerBase
    {
        private ServicioBL reservaBL = new ServicioBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Servicio>> Get()
        {
            return await reservaBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Servicio> Get(int id)
        {
            Servicio reserva = new Servicio();
            reserva.Id = id;
            return await reservaBL.ObtenerPorIdAsync(reserva);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Servicio Servicio)
        {
            try
            {
                await reservaBL.crearAsync(Servicio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Servicio servicio)
        {

            if (servicio.Id == id)
            {
                await reservaBL.ModificarAsync(servicio);
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
                Servicio reserva = new Servicio();
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
        public async Task<List<Servicio>> Buscar([FromBody] object pServicio)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strReserva = JsonSerializer.Serialize(pServicio);
            Servicio reserva = JsonSerializer.Deserialize<Servicio>(strReserva, option);
            return await reservaBL.BuscarAsync(reserva);
        }
    }
}
