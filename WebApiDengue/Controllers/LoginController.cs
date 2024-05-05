using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using WebApiDengue.Entities;
using WebApiDengue.Repository;

namespace WebApiDengue.Controllers
{
    [Route("Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private RepUsuario _repUsuario; 

        public LoginController()
        {
            _repUsuario = new RepUsuario();
        }


        [HttpPost("ValidarUser")]
        public IActionResult LoginUser(ModUser modUsuario)
        {
            bool usuario = _repUsuario.VerficarUsuario(modUsuario.usuario, modUsuario.clave);
            if (usuario)
            {
                return Ok(new
                {
                    msg = "Acceso correcto",
                    data = usuario,
                });
            }
            else
            {
                return Ok(new
                {
                    msg = "Usuario o Contraseña Incorrecta",
                    data = usuario,
                });
            }
        }

    }
}
