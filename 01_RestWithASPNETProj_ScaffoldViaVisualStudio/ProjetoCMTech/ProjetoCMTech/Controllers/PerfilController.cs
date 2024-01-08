using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    //[Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PerfilController : ControllerBase
    {



        private readonly ILogger<PerfilController> _logger;

        private IPerfilBusiness _perfilBusiness;

        public PerfilController(ILogger<PerfilController> logger, IPerfilBusiness perfilBusiness)
        {
            _logger = logger;
            _perfilBusiness = perfilBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<PerfilVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_perfilBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PerfilVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var perfil = _perfilBusiness.FindByID(id);
            if (perfil == null) return NotFound();
            return Ok(perfil);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(PerfilVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] PerfilVO perfil)
        {
            if (perfil == null) return BadRequest();
            return Ok(_perfilBusiness.Create(perfil));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PerfilVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] PerfilVO perfil)
        {
            if (perfil == null) return BadRequest();
            return Ok(_perfilBusiness.Update(perfil));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _perfilBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
