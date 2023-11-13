using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
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
        public IActionResult Get()
        {

            return Ok(_perfilBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var perfil = _perfilBusiness.FindByID(id);
            if (perfil == null) return NotFound();
            return Ok(perfil);
        }

        [HttpPost]
        public IActionResult Post([FromBody] PerfilVO perfil)
        {
            if (perfil == null) return BadRequest();
            return Ok(_perfilBusiness.Create(perfil));
        }

        [HttpPut]

        public IActionResult Put([FromBody] PerfilVO perfil)
        {
            if (perfil == null) return BadRequest();
            return Ok(_perfilBusiness.Update(perfil));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _perfilBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
