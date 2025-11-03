using Edus.Share.Model;
using Edus.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;





namespace Edus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteFarmaciaController : ControllerBase
    {
        [HttpGet]
        [Route("getClienteFarmacia")]
        public async Task<ActionResult<List<cClienteFarmacia>>> getClienteFarmacia()
        {
            try
            {
                dbConection db = new dbConection();
                dsClienteFarmacia mdsCat= new dsClienteFarmacia(db.sqlConection);
                List<cClienteFarmacia> mLista = await mdsCat.getClienteFarmacia();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("insertarClienteFarmacia")]
        public async Task<ActionResult<bool>> insertarClienteFarmacia([FromBody] cClienteFarmacia _cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos del cliente inválidos.");

            try
            {
                dbConection db = new dbConection();
                dsClienteFarmacia mdsCat = new dsClienteFarmacia(db.sqlConection);

                bool resultado = await mdsCat.insertarClienteFarmacia(_cliente);

                if (resultado)
                    return Ok(true);
                else
                    return BadRequest("No se pudo insertar el cliente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al insertar el cliente: " + ex.Message);
            }
        }
    }
}
