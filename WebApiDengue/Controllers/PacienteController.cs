using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
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

        public PacienteController(IRepFuncionGenerico repFuncionGenerico)
        {
            this._repFuncionGenerico = repFuncionGenerico;
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



    }
}
