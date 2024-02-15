using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Business;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
   

    public class StatusUsuarioController : ControllerBase
    {

        private readonly ILogger <StatusUsuarioController> _logger;

        private IStatusUsuarioBusiness _statusUsuarioBusiness;

        public StatusUsuarioController(ILogger<StatusUsuarioController> logger, IStatusUsuarioBusiness statusUsuarioBusiness)
        {
            _logger = logger;
            _statusUsuarioBusiness = statusUsuarioBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<StatusUsuarioVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {
            return Ok(_statusUsuarioBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(List<StatusUsuarioVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {   
            var statusUsuario = _statusUsuarioBusiness.FindByID(id);
            if (statusUsuario == null) return NotFound();
            return Ok(statusUsuario);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(StatusUsuarioVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Post([FromBody]  StatusUsuarioVO statusUsuario)
        {
            if (statusUsuario == null) return BadRequest();
            return Ok(_statusUsuarioBusiness.Create(statusUsuario));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(StatusUsuarioVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Put([FromBody] StatusUsuarioVO statusUsuario)
        {
            if (statusUsuario == null) return BadRequest();
            return Ok(_statusUsuarioBusiness.Update(statusUsuario));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {   
            _statusUsuarioBusiness.Delete(id);
            return NoContent();
        }
    }
}
