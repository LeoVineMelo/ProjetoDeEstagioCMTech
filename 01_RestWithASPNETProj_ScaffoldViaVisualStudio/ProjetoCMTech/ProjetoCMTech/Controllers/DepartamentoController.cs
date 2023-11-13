using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Get()
        {

            return Ok(_departamentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var departamento = _departamentoBusiness.FindByID(id);
            if (departamento == null) return NotFound();
            return Ok(departamento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] DepartamentoVO departamento)
        {
            if (departamento == null) return BadRequest();
            return Ok(_departamentoBusiness.Create(departamento));
        }

        [HttpPut]

        public IActionResult Put([FromBody] DepartamentoVO departamento)
        {
            if (departamento == null) return BadRequest();
            return Ok(_departamentoBusiness.Update(departamento));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _departamentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
