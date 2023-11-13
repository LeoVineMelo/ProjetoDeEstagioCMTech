using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
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
        public IActionResult Get()
        {

            return Ok(_changelogBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var changelog = _changelogBusiness.FindByID(id);
            if (changelog == null) return NotFound();
            return Ok(changelog);
        }

        [HttpPost]
        public IActionResult Post([FromBody] ChangelogVO changelog)
        {
            if (changelog == null) return BadRequest();
            return Ok(_changelogBusiness.Create(changelog));
        }

        [HttpPut]

        public IActionResult Put([FromBody] ChangelogVO changelog)
        {
            if (changelog == null) return BadRequest();
            return Ok(_changelogBusiness.Update(changelog));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _changelogBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
