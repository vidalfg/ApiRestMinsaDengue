using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WebApiDengue.Entities;
using WebApiDengue.Resources.Data;
using WebApiDengue.Resources.Repository;
using WebApiDengue.Resources.Utility;

namespace WebApiDengue.Controllers
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private IRepFuncionGenerico _repFuncionGenerico;
        private Funciones _funciones;
        public PacienteController(IRepFuncionGenerico repFuncionGenerico)
        {
            this._repFuncionGenerico = repFuncionGenerico;
            this._funciones = new Funciones();
        }

        [HttpGet("ListarInitForm")]
        public async Task<IActionResult> ListarInitForm() {

            List<Parameter> parametros = new List<Parameter>
            {
              new Parameter("@Data","data"),
            };

            dynamic resultado = await _repFuncionGenerico.Listar("usp_Paciente_InitForm", parametros, true);

            return Content(resultado, "application/json");
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> Listar()
        {

            List<Parameter> parametros = new List<Parameter>
            {
              new Parameter("@Data","data"),
            };

            dynamic resultado = await _repFuncionGenerico.Listar("usp_Paciente_Listar", parametros, true);

            return Content(resultado, "application/json");
        }

        [HttpPost("InserUpdate")]
        public async Task<IActionResult> InserUpdate([FromBody] ModPaciente paciente)
        {
            var jsonString = JsonConvert.SerializeObject(paciente) ?? string.Empty;


            if (_funciones.IsValidJson(jsonString))
            {
                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonString),
                };

                dynamic resultado = await _repFuncionGenerico.Listar("usp_Paciente_InsertUpdate", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Formato de Json No es valido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }


        [HttpDelete("eliminar")]
        public async Task<IActionResult> Delete(int idPaciente = 0, string userAccion = "")
        {
            if (idPaciente > 0)
            {
                var dataResult = (new
                {
                    idPaciente = idPaciente,
                    userAccion = userAccion,
                });

                var jsonStringData = JsonConvert.SerializeObject(dataResult);

                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonStringData),
                };
                dynamic resultado = await _repFuncionGenerico.Listar("usp_Paciente_Delete", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Codigo Invalido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("Obetener")]
        public async Task<IActionResult> Obtener(int idPaciente =0)
        {

            if (idPaciente > 0)
            { 
                var dataResult = (new
                {
                    idPaciente = idPaciente
                });

                var jsonStringData = JsonConvert.SerializeObject(dataResult);

                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonStringData),
                };
                dynamic resultado = await _repFuncionGenerico.Listar("usp_Paciente_Obtener", parametros, true);
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
