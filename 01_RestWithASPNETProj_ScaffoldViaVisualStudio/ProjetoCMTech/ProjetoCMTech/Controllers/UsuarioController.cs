using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

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
        [ProducesResponseType((200), Type = typeof(List<UsuarioVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_usuarioBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var usuario = _usuarioBusiness.FindByID(id);
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.Create(usuario));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(UsuarioVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] UsuarioVO usuario)
        {
            if (usuario == null) return BadRequest();
            return Ok(_usuarioBusiness.Update(usuario));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _usuarioBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
