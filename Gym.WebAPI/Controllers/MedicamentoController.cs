using Edus.Share.Model;
using Edus.Share.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;




namespace Edus.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicamentoController : ControllerBase
    {       
            [HttpGet]
            [Route("getMedicamento")]
            public async Task<ActionResult<List<cMedicamento>>> getMedicamento()
            {
                try
                {
                    dbConection db = new dbConection();
                dsMedicamento mdsCat = new dsMedicamento(db.sqlConection);
                    List<cMedicamento> mLista = await mdsCat.getMedicamento();
                    return Ok(mLista);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            //****************************************************************************************************
            [HttpPost]
            [Route("insertarMedicamento")]
            public async Task<ActionResult<bool>> insertarMedicamento([FromBody] cMedicamento _Medicamento)
            {
                if (!ModelState.IsValid)
                    return BadRequest("Datos del Medicamento inválidos.");

                try
                {
                    dbConection db = new dbConection();
                dsMedicamento mdsCat = new dsMedicamento(db.sqlConection);

                    bool resultado = await mdsCat.insertarMedicamento(_Medicamento);

                    if (resultado)
                        return Ok(true);
                    else
                        return BadRequest("No se pudo insertar el Medicamento.");
                }
                catch (Exception ex)
                {
                    return BadRequest("Error al insertar el Medicamento: " + ex.Message);
                }
            }
            //****************************************************************************************************
            [HttpPut]
            [Route("actualizarMedicamento")]
            public async Task<ActionResult<string>> actualizarMedicamento([FromBody] cMedicamento _Medicamento)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                try
                {
                    dbConection db = new dbConection();
                dsMedicamento ndsMedicamento = new dsMedicamento(db.sqlConection);

                    if (await ndsMedicamento.actualizarMedicamento(_Medicamento) == true)
                    {
                        return Ok("Medicamento actualizado correctamente.");
                    }
                    else
                    {
                        return BadRequest("No se pudo actualizar el Medicamento.");
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
        [Route("borrarclienteMedicamento/{IdMedicamento}")]
        public async Task<ActionResult<string>> borrarMedicamento(int IdMedicamento)
        {
            try
            {
                dbConection db = new dbConection();
                dsMedicamento ndsMedicamento = new dsMedicamento(db.sqlConection);

                cMedicamento Medicamento = new cMedicamento();
                Medicamento.IdMedicamento = IdMedicamento;

                if (await ndsMedicamento.borrarMedicamento(Medicamento))
                {
                    return Ok("Medicamento eliminado correctamente.");
                }
                else
                {
                    return NotFound("No se encontró un Medicamento con esa identificación.");
                }
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al eliminar Medicamento: {ex.Message}");
            }
        }





    }
    }

