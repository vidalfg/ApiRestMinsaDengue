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
        public async Task<IActionResult> InserUpdateDelete([FromBody] ModMedico medico)
        {
            var jsonString = JsonConvert.SerializeObject(medico) ?? string.Empty;


            if (_funciones.IsValidJson(jsonString))
            {
                //var data = JsonConvert.DeserializeObject<dynamic>(jsonString);
                //var jsonStringData = JsonConvert.SerializeObject(data);

                List<Parameter> parametros = new List<Parameter>
                {
                    new Parameter("@Data",jsonString),
                };

                dynamic resultado = await _repFuncionGenerico.Listar("usp_Medico_Listar", parametros, true);
                return Content(resultado, "application/json");
            }
            else
            {
                Response<object> errorResponse = new Response<object>(false, 400, "Formato de Json No es valido.", new List<object>());
                return BadRequest(errorResponse);
            }
        }
    }
}
