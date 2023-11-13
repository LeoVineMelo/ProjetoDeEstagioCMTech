using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Get()
        {

            return Ok(_chatatendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var chatatendimento = _chatatendimentoBusiness.FindByID(id);
            if (chatatendimento == null) return NotFound();
            return Ok(chatatendimento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChatAtendimentoVO chatatendimento)
        {
            if (chatatendimento == null) return BadRequest();
            return Ok(_chatatendimentoBusiness.Create(chatatendimento));
        }

        [HttpPut]

        public IActionResult Put([FromBody] ChatAtendimentoVO chatatendimento)
        {
            if (chatatendimento == null) return BadRequest();
            return Ok(_chatatendimentoBusiness.Update(chatatendimento));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _chatatendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
