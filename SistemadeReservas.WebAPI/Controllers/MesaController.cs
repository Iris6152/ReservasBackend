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
    public class MesaController : ControllerBase
    {
        private MesaBL servicioBL = new MesaBL();

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<Mesa>> Get()
        {
            return await servicioBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Mesa> Get(int id)
        {
            Mesa depto = new Mesa();
            depto.Id = id;
            return await servicioBL.ObtenerPorIdAsync(depto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Mesa mesa)
        {
            try
            {
                await servicioBL.crearAsync(mesa);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mesa mesa)
        {

            if (mesa.Id == id)
            {
                await servicioBL.ModificarAsync(mesa);
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
                Mesa servicio = new Mesa();
                servicio.Id = id;
                await servicioBL.EliminarAsync(servicio);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Mesa>> Buscar([FromBody] object pMesa)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strServicio = JsonSerializer.Serialize(pMesa);
            Mesa servicio = JsonSerializer.Deserialize<Mesa>(strServicio, option);
            return await servicioBL.BuscarAsync(servicio);
        }

    }
}
