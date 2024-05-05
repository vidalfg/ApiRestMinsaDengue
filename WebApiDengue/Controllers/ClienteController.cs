using Microsoft.AspNetCore.Mvc;

namespace WebApiDengue.Controllers
{
    [ApiController]
    [Route("cliente")]
    public class ClienteController : ControllerBase
    {

        [HttpGet]
        [Route("listar")]
        public dynamic listarCliente()
        {
            //todo el codigo
            return new
            {
                nombre = "Jesus",
                edad = 25
            };
        }

        //[HttpGet]
        //[Route("guardar")]
        //public dynamic saveCliente()
        //{

        //}
    }
}
