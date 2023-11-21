using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class StatusAtendimentoController : ControllerBase
    {



        private readonly ILogger<StatusAtendimentoController> _logger;

        private IStatusAtendimentoBusiness _statusatendimentoBusiness;

        public StatusAtendimentoController(ILogger<StatusAtendimentoController> logger, IStatusAtendimentoBusiness statusatendimentoBusiness)
        {
            _logger = logger;
            _statusatendimentoBusiness = statusatendimentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<StatusAtendimentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_statusatendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(StatusAtendimentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var statusatendimento = _statusatendimentoBusiness.FindByID(id);
            if (statusatendimento == null) return NotFound();
            return Ok(statusatendimento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(StatusAtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] StatusAtendimentoVO statusatendimento)
        {
            if (statusatendimento == null) return BadRequest();
            return Ok(_statusatendimentoBusiness.Create(statusatendimento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(StatusAtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] StatusAtendimentoVO statusatendimento)
        {
            if (statusatendimento == null) return BadRequest();
            return Ok(_statusatendimentoBusiness.Update(statusatendimento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _statusatendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
