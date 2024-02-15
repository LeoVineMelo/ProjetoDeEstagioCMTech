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
    public class AtendimentoController : ControllerBase
    {



        private readonly ILogger<AtendimentoController> _logger;

        private IAtendimentoBusiness _atendimentoBusiness;

        public AtendimentoController(ILogger<AtendimentoController> logger, IAtendimentoBusiness atendimentoBusiness)
        {
            _logger = logger;
            _atendimentoBusiness = atendimentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<AtendimentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_atendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(AtendimentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var atendimento = _atendimentoBusiness.FindByID(id);
            if (atendimento == null) return NotFound();
            return Ok(atendimento);
        }
        [HttpPost("search")]
        [ProducesResponseType((200), Type = typeof(AtendimentoPesquisaVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Search([FromBody] AtendimentoPesquisaVO pesquisa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (pesquisa == null) return BadRequest();
            var itens = _atendimentoBusiness.FindAll(pesquisa);
            var total = _atendimentoBusiness.FindAllCount(pesquisa);
            return Ok(itens);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(AtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] AtendimentoVO atendimento)
        {
            if (atendimento == null) return BadRequest();
            return Ok(_atendimentoBusiness.Create(atendimento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(AtendimentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] AtendimentoVO atendimento)
        {
            if (atendimento == null) return BadRequest();
            return Ok(_atendimentoBusiness.Update(atendimento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _atendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
