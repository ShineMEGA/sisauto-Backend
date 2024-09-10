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
    
    public class OrdenesController : ControllerBase
    {
        private readonly SisautoContext _context; // inyeccion de dependencias _""
        private readonly OrdenesService _ordenesService; //inyectar el servicio 
        public OrdenesController(SisautoContext context, OrdenesService ordenesService) //ctor + tab
        {
            _context = context;
            _ordenesService = ordenesService; // es necsario colocar en el constructor 
        }
        // GET: api/<OrdenesController>
        [HttpGet] // protege las URLS ERROR 401 NO AUTORIZADO
        public async Task<ActionResult<IEnumerable<Ordenes>>> Get()
        {
            return Ok(await _ordenesService.GetAll()); // solamente va llamar al servicio de ordenes

        }

        // GET api/<OrdenesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ordenes>> GetById(int id)
        {
            return Ok(await _ordenesService.GetById(id));
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public async Task<IActionResult> Post(Ordenes pais)
        {
            return Ok(await _ordenesService.Create(pais));
        }

        // PUT api/<OrdenesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Ordenes pais)
        {
            return Ok(await _ordenesService.Update(pais));
        }

        // DELETE api/<OrdenesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ordenesService.Delete(id);
            return Ok("{message:Deleted}");
        }
    }
}
