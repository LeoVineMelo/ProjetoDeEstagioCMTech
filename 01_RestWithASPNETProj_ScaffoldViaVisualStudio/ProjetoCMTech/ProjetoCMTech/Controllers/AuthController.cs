using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Business;
using ProjetoCMTech.Data.VO;
using ProjetoCMTech.Model;
using ProjetoCMTech.Repository;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private ILoginBusiness _loginBusiness;
        private IUsuarioRepository _usuarioRepository;

        public AuthController(ILoginBusiness loginBusiness, IUsuarioRepository usuarioRepository)
        {
            _loginBusiness = loginBusiness;
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UsuarioLoginVO usuario)
        {
            if (usuario == null) return BadRequest("requerimento de cliente inválido");

            var token = _loginBusiness.ValidateCredentials(usuario);
            if (token == null) return Unauthorized();
            return Ok(new
            {
                credentials = token
            });
        }
    }
}
