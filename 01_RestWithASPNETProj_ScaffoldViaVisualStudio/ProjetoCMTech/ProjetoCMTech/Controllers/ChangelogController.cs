using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [Authorize("Bearer")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ChangelogController : ControllerBase
    {



        private readonly ILogger<ChangelogController> _logger;

        private IChangelogBusiness _changelogBusiness;

        public ChangelogController(ILogger<ChangelogController> logger, IChangelogBusiness changelogBusiness)
        {
            _logger = logger;
            _changelogBusiness = changelogBusiness;
        }

        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<ChangelogVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_changelogBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(ChangelogVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var changelog = _changelogBusiness.FindByID(id);
            if (changelog == null) return NotFound();
            return Ok(changelog);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(ChangelogVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] ChangelogVO changelog)
        {
            if (changelog == null) return BadRequest();
            return Ok(_changelogBusiness.Create(changelog));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(ChangelogVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] ChangelogVO changelog)
        {
            if (changelog == null) return BadRequest();
            return Ok(_changelogBusiness.Update(changelog));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _changelogBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
