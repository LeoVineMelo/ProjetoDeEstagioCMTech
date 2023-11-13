using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Get()
        {

            return Ok(_atendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var atendimento = _atendimentoBusiness.FindByID(id);
            if (atendimento == null) return NotFound();
            return Ok(atendimento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AtendimentoVO atendimento)
        {
            if (atendimento == null) return BadRequest();
            return Ok(_atendimentoBusiness.Create(atendimento));
        }

        [HttpPut]

        public IActionResult Put([FromBody] AtendimentoVO atendimento)
        {
            if (atendimento == null) return BadRequest();
            return Ok(_atendimentoBusiness.Update(atendimento));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _atendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
