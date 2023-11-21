using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
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
        [ProducesResponseType((200), Type = typeof(List<GrupoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_grupoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(GrupoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var grupo = _grupoBusiness.FindByID(id);
            if (grupo == null) return NotFound();
            return Ok(grupo);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(GrupoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] GrupoVO grupo)
        {
            if (grupo == null) return BadRequest();
            return Ok(_grupoBusiness.Create(grupo));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(GrupoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] GrupoVO grupo)
        {
            if (grupo == null) return BadRequest();
            return Ok(_grupoBusiness.Update(grupo));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _grupoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
