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
        [ProducesResponseType((200), Type = typeof(List<OrganizacaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_organizacaoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(OrganizacaoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var organizacao = _organizacaoBusiness.FindByID(id);
            if (organizacao == null) return NotFound();
            return Ok(organizacao);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(OrganizacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] OrganizacaoVO organizacao)
        {
            if (organizacao == null) return BadRequest();
            return Ok(_organizacaoBusiness.Create(organizacao));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(OrganizacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] OrganizacaoVO organizacao)
        {
            if (organizacao == null) return BadRequest();
            return Ok(_organizacaoBusiness.Update(organizacao));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _organizacaoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
