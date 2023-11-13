using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class UsuarioController : ControllerBase
    {



        private readonly ILogger<UsuarioController> _logger;

        private IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(ILogger<UsuarioController> logger, IUsuarioBusiness usuarioBusiness)
        {
            _logger = logger;
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_usuarioBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var usuario = _usuarioBusiness.FindByID(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.Create(usuario));
        }

        [HttpPut]

        public IActionResult Put([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.Update(usuario));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _usuarioBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
