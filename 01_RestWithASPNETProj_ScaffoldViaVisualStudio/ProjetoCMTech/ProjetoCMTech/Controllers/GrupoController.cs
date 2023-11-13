using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using System.Text.RegularExpressions;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class GrupoController : ControllerBase
    {



        private readonly ILogger<GrupoController> _logger;

        private IGrupoBusiness _grupoBusiness;

        public GrupoController(ILogger<GrupoController> logger, IGrupoBusiness grupoBusiness)
        {
            _logger = logger;
            _grupoBusiness = grupoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_grupoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var grupo = _grupoBusiness.FindByID(id);
            if (grupo == null) return NotFound();
            return Ok(grupo);
        }

        [HttpPost]
        public IActionResult Post([FromBody] GrupoVO grupo)
        {
            if (grupo == null) return BadRequest();
            return Ok(_grupoBusiness.Create(grupo));
        }

        [HttpPut]

        public IActionResult Put([FromBody] GrupoVO grupo)
        {
            if (grupo == null) return BadRequest();
            return Ok(_grupoBusiness.Update(grupo));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _grupoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
