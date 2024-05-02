using Microsoft.AspNetCore.Mvc;
using ProjetoCMTech.Model;
using ProjetoCMTech.Business;
using Microsoft.AspNetCore.Authorization;
using ProjetoCMTech.Data.VO;

namespace ProjetoCMTech.Controllers
{
    [ApiVersion("1")]
    [ApiController]
   // [Authorize("Bearer")]
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
        [ProducesResponseType((200), Type = typeof(List<SegmentoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get()
        {

            return Ok(_segmentoBusiness.FindAll());
        }
        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(SegmentoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Get(long id)
        {
            var segmento = _segmentoBusiness.FindByID(id);
            if (segmento == null) return NotFound();
            return Ok(segmento);
        }

        [HttpPost]
        [ProducesResponseType((200), Type = typeof(SegmentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Post([FromBody] SegmentoVO segmento)
        {
            if (segmento == null) return BadRequest();
            return Ok(_segmentoBusiness.Create(segmento));
        }

        [HttpPut]
        [ProducesResponseType((200), Type = typeof(SegmentoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]


        public IActionResult Put([FromBody] SegmentoVO segmento)
        {
            if (segmento == null) return BadRequest();
            return Ok(_segmentoBusiness.Update(segmento));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]

        public IActionResult Delete(long id)
        {
            _segmentoBusiness.Delete(id);
             return NoContent();            
        }    
    }
}
