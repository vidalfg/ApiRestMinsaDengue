using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApiDengue.Entities;
using WebApiDengue.Resources.Data;
using WebApiDengue.Resources.Repository;
using WebApiDengue.Resources.Utility;

namespace WebApiDengue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {

        private IRepFuncionGenerico _repFuncionGenerico;
        private Funciones _funciones;
        public MedicoController(IRepFuncionGenerico repFuncionGenerico)
        {
            this._repFuncionGenerico = repFuncionGenerico;
            this._funciones = new Funciones();
        }


        [HttpGet("ListarInitForm")]
        public async Task<IActionResult> ListarInitForm()
        {

            List<Parameter> parametros = new List<Parameter>
            {
              new Parameter("@Data","data"),
            };

            dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_InitForm", parametros, true);

            return Content(resultado, "application/json");
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {

            List<Parameter> parametros = new List<Parameter>
            {
              new Parameter("@Data","data"),
            };

            dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_Listar", parametros, true);

            return Content(resultado, "application/json");
        }


        [HttpPost("InserUpdate")]
        public async Task<IActionResult> InserUpdate([FromBody] ModMedico medico)
        {
            var jsonString = JsonConvert.SerializeObject(medico) ?? string.Empty;


            if (_funciones.IsValidJson(jsonString))
            {
                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonString),
                };

                dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_InsertUpdate", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Formato de Json No es valido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("eliminar")]
        public async Task<IActionResult> Delete(int idMedico = 0,string userAccion ="")
        {
            if (idMedico>0)
            {
                var dataResult = (new
                {
                    idMedico = idMedico,
                    userAccion = userAccion,
                }); 

                var jsonStringData = JsonConvert.SerializeObject(dataResult);

                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonStringData),
                };
                dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_Delete", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Codigo Invalido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("Obtener")]
        public async Task<IActionResult> Obtener(int idMedico = 0)
        {
            if (idMedico > 0)
            {
                var dataResult = (new
                {
                    idMedico = idMedico
                });

                var jsonStringData = JsonConvert.SerializeObject(dataResult);

                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonStringData),
                };
                dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_Obtener", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Codigo Invalido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }
    }
}
