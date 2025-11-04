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

        //****************************************************************************************************
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
        //****************************************************************************************************
        [HttpPut]
        [Route("actualizarclienteFarmacia")]
        public async Task<ActionResult<string>> actualizarClienteFarmacia([FromBody] cClienteFarmacia _cliente)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                dbConection db = new dbConection();
                dsClienteFarmacia ndsCliente = new dsClienteFarmacia(db.sqlConection);

                if (await ndsCliente.actualizarClienteFarmacia(_cliente) == true)
                {
                    return Ok("Cliente actualizado correctamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el cliente.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    error = ex.Message,
                    inner = ex.InnerException?.Message
                });
            }
        }
        //******************************************************************************************************
        [HttpDelete]
        [Route("borrarclienteclienteFarmacia/{Identificacion}")]
        public async Task<ActionResult<string>> borrarClienteFarmacia(string Identificacion)
        {
            try
            {
                dbConection db = new dbConection();
                dsClienteFarmacia ndsCliente = new dsClienteFarmacia(db.sqlConection);

                cClienteFarmacia cliente = new cClienteFarmacia();
                cliente.Identificacion = Identificacion;

                if (await ndsCliente.borrarClienteFarmacia(cliente))
                {
                    return Ok("Cliente eliminado correctamente.");
                }
                else
                {
                    return NotFound("No se encontró un cliente con esa identificación.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar cliente: {ex.Message}");
            }
        }





    }
}
