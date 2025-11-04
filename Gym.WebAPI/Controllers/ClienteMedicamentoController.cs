using Edus.Share.Model;
using Edus.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;





namespace Edus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteMedicamentoController : ControllerBase
    {
        [HttpGet]
        [Route("getClienteMedicamento")]
        public async Task<ActionResult<List<cClienteMedicamento>>> getClienteMedicamento()
        {
            try
            {
                dbConection db = new dbConection();
                dsClienteMedicamento mdsCat = new dsClienteMedicamento(db.sqlConection);
                List<cClienteMedicamento> mLista = await mdsCat.getClienteMedicamento();
                return Ok(mLista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //****************************************************************************************************
        [HttpPost]
        [Route("insertarClienteMedicamento")]
        public async Task<ActionResult<bool>> insertarClienteMedicamento([FromBody] cClienteMedicamento _ClienteMedicamento)
        {
            if (!ModelState.IsValid)
                return BadRequest("Datos del Medicamiento cliente inválidos.");

            try
            {
                dbConection db = new dbConection();
                dsClienteMedicamento mdsCat = new dsClienteMedicamento(db.sqlConection);

                bool resultado = await mdsCat.insertarClienteMedicamento(_ClienteMedicamento);

                if (resultado)
                    return Ok(true);
                else
                    return BadRequest("No se pudo insertar el Medicamiento cliente.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error al insertar el Medicamiento cliente: " + ex.Message);
            }
        }
        //****************************************************************************************************
        [HttpPut]
        [Route("actualizarClienteMedicamento")]
        public async Task<ActionResult<string>> actualizarClienteMedicamento([FromBody] cClienteMedicamento _ClienteMedicamento)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                dbConection db = new dbConection();
                dsClienteMedicamento ndsCliente = new dsClienteMedicamento(db.sqlConection);

                if (await ndsCliente.actualizarClienteMedicamento(_ClienteMedicamento) == true)
                {
                    return Ok("Medicamiento Cliente actualizado correctamente.");
                }
                else
                {
                    return BadRequest("No se pudo actualizar el Medicamiento cliente.");
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
        [Route("borrarClienteMedicamento/{Identificacion}/{IdMedicamento}")]
        public async Task<ActionResult<string>> borrarClienteMedicamento(int Identificacion, int IdMedicamento)
        {
            try
            {
                dbConection db = new dbConection();
                dsClienteMedicamento ndsClienteMedicamento = new dsClienteMedicamento(db.sqlConection);

                // Creamos el objeto con ambos valores
                cClienteMedicamento ClienteMedicamento = new cClienteMedicamento
                {
                    Identificacion = Identificacion,
                    IdMedicamento = IdMedicamento
                };

                // Intentamos eliminar el registro
                if (await ndsClienteMedicamento.borrarClienteMedicamento(ClienteMedicamento))
                {
                    return Ok("ClienteMedicamento eliminado correctamente.");
                }
                else
                {
                    return NotFound("No se encontró un registro de ClienteMedicamento con esos datos.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar ClienteMedicamento: {ex.Message}");
            }
        }






    }
}           





        
    


















