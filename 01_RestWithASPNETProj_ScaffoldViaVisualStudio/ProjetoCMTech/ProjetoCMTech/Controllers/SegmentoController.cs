using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class SegmentoController : ControllerBase
    {



        private readonly ILogger<SegmentoController> _logger;

        private ISegmentoBusiness _segmentoBusiness;

        public SegmentoController(ILogger<SegmentoController> logger, ISegmentoBusiness segmentoBusiness)
        {
            _logger = logger;
            _segmentoBusiness = segmentoBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_segmentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var segmento = _segmentoBusiness.FindByID(id);
            if (segmento == null) return NotFound();
            return Ok(segmento);
        }

        [HttpPost]
        public IActionResult Post([FromBody] SegmentoVO segmento)
        {
            if (segmento == null) return BadRequest();
            return Ok(_segmentoBusiness.Create(segmento));
        }

        [HttpPut]

        public IActionResult Put([FromBody] SegmentoVO segmento)
        {
            if (segmento == null) return BadRequest();
            return Ok(_segmentoBusiness.Update(segmento));
        }

        [HttpDelete("{id}")]

        public IActionResult Delete(long id)
        {
            _segmentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
