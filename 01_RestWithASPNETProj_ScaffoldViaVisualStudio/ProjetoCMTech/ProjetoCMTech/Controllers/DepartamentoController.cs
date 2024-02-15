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
    public class DepartamentoController : ControllerBase
    {



        private readonly ILogger<DepartamentoController> _logger;

        private IDepartamentoBusiness _departamentoBusiness;

        public DepartamentoController(ILogger<DepartamentoController> logger, IDepartamentoBusiness departamentoBusiness)
        {
            _logger = logger;
            _departamentoBusiness = departamentoBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<DepartamentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_departamentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(DepartamentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var departamento = _departamentoBusiness.FindByID(id);
            if (departamento == null) return NotFound();
            return Ok(departamento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(DepartamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] DepartamentoVO departamento)
        {
            if (departamento == null) return BadRequest();
            return Ok(_departamentoBusiness.Create(departamento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(DepartamentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] DepartamentoVO departamento)
        {
            if (departamento == null) return BadRequest();
            return Ok(_departamentoBusiness.Update(departamento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _departamentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
