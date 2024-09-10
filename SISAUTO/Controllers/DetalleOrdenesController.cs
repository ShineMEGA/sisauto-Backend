using DB.Models;
using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service;
using Microsoft.AspNetCore.Cors;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DetalleOrdenesController : ControllerBase
    {
        private readonly SisautoContext _context; // inyeccion de dependencias _""
        private readonly DetalleOrdenesService _detalleOrdenesService; //inyectar el servicio 
        public DetalleOrdenesController(SisautoContext context, DetalleOrdenesService detalleOrdenesService) //ctor + tab
        {
            _context = context;
            _detalleOrdenesService = detalleOrdenesService; // es necsario colocar en el constructor 
        }
        // GET: api/<DetalleOrdenesController>
        [HttpGet] // protege las URLS ERROR 401 NO AUTORIZADO
        public async Task<ActionResult<IEnumerable<DetalleOrdenes>>> Get()
        {
            return Ok(await _detalleOrdenesService.GetAll()); // solamente va llamar al servicio de detalleOrdenes

        }


        // GET api/<DetalleOrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleOrdenes>> GetById(int id)
        {
            return Ok(await _detalleOrdenesService.GetById(id));
        }

        // POST api/<DetalleOrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(DetalleOrdenes pais)
        {
            return Ok(await _detalleOrdenesService.Create(pais));
        }

        // PUT api/<DetalleOrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, DetalleOrdenes pais)
        {
            return Ok(await _detalleOrdenesService.Update(pais));
        }

        // DELETE api/<DetalleOrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _detalleOrdenesService.Delete(id);
            return Ok("{message:Deleted}");
        }
    }
}
