using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class OrganizacaoController : ControllerBase
    {



        private readonly ILogger<OrganizacaoController> _logger;

        private IOrganizacaoBusiness _organizacaoBusiness;

        public OrganizacaoController(ILogger<OrganizacaoController> logger, IOrganizacaoBusiness organizacaoBusiness)
        {
            _logger = logger;
            _organizacaoBusiness = organizacaoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_organizacaoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var organizacao = _organizacaoBusiness.FindByID(id);
            if (organizacao == null) return NotFound();
            return Ok(organizacao);
        }

        [HttpPost]
        public IActionResult Post([FromBody] OrganizacaoVO organizacao)
        {
            if (organizacao == null) return BadRequest();
            return Ok(_organizacaoBusiness.Create(organizacao));
        }

        [HttpPut]

        public IActionResult Put([FromBody] OrganizacaoVO organizacao)
        {
            if (organizacao == null) return BadRequest();
            return Ok(_organizacaoBusiness.Update(organizacao));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _organizacaoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
