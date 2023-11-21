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
    public class ChatAtendimentoController : ControllerBase
    {



        private readonly ILogger<ChatAtendimentoController> _logger;

        private IChatAtendimentoBusiness _chatatendimentoBusiness;

        public ChatAtendimentoController(ILogger<ChatAtendimentoController> logger, IChatAtendimentoBusiness chatatendimentoBusiness)
        {
            _logger = logger;
            _chatatendimentoBusiness = chatatendimentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<ChatAtendimentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_chatatendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ChatAtendimentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var chatatendimento = _chatatendimentoBusiness.FindByID(id);
            if (chatatendimento == null) return NotFound();
            return Ok(chatatendimento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(ChatAtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ChatAtendimentoVO chatatendimento)
        {
            if (chatatendimento == null) return BadRequest();
            return Ok(_chatatendimentoBusiness.Create(chatatendimento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ChatAtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] ChatAtendimentoVO chatatendimento)
        {
            if (chatatendimento == null) return BadRequest();
            return Ok(_chatatendimentoBusiness.Update(chatatendimento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _chatatendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
