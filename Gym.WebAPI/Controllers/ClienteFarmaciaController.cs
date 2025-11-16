using Edus.Share.Model;
using Edus.Share.Service;
using Microsoft.AspNetCore.Mvc;

namespace Edus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteFarmaciaController : ControllerBase
    {
        [HttpGet("getClienteFarmacia")]
        public async Task<ActionResult<List<cClienteFarmacia>>> GetClienteFarmacia()
        {
            try
            {
                var db = new dbConection();
                var ds = new dsClienteFarmacia(db.sqlConection);
                var lista = await ds.getClienteFarmacia();
                return Ok(lista);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPost("insertarClienteFarmacia")]
        public async Task<ActionResult<bool>> InsertarClienteFarmacia([FromBody] cClienteFarmacia cliente)
        {
            if (cliente == null) return BadRequest("Datos inválidos");
            try
            {
                var db = new dbConection();
                var ds = new dsClienteFarmacia(db.sqlConection);
                var ok = await ds.insertarClienteFarmacia(cliente);
                return ok ? Ok(true) : BadRequest(false);
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpPut("actualizarClienteFarmacia")]
        public async Task<ActionResult<string>> ActualizarClienteFarmacia([FromBody] cClienteFarmacia cliente)
        {
            if (cliente == null) return BadRequest("Datos inválidos");
            try
            {
                var db = new dbConection();
                var ds = new dsClienteFarmacia(db.sqlConection);
                var ok = await ds.actualizarClienteFarmacia(cliente);
                return ok ? Ok("Actualizado") : NotFound("No encontrado");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        [HttpDelete("borrarClienteFarmacia/{identificacion}")]
        public async Task<ActionResult<string>> BorrarClienteFarmacia(string identificacion)
        {
            if (string.IsNullOrWhiteSpace(identificacion)) return BadRequest("Identificación requerida");
            try
            {
                var db = new dbConection();
                var ds = new dsClienteFarmacia(db.sqlConection);
                var ok = await ds.borrarClienteFarmacia(new cClienteFarmacia { Identificacion = identificacion });
                return ok ? Ok("Eliminado") : NotFound("No encontrado");
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
