using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Get()
        {

            return Ok(_statusatendimentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _statusatendimentoBusiness.FindByID(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] StatusAtendimentoVO statusatendimento)
        {
            if (statusatendimento == null) return BadRequest();
            return Ok(_statusatendimentoBusiness.Create(statusatendimento));
        }

        [HttpPut]

        public IActionResult Put([FromBody] StatusAtendimentoVO statusatendimento)
        {
            if (statusatendimento == null) return BadRequest();
            return Ok(_statusatendimentoBusiness.Update(statusatendimento));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _statusatendimentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
