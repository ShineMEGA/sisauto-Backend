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
    
    public class ServiciosController : ControllerBase
    {
        private readonly SisautoContext _context; // inyeccion de dependencias _""
        private readonly ServiciosService _ServiciosService; //inyectar el servicio 
        public ServiciosController(SisautoContext context, ServiciosService ServiciosService) //ctor + tab
        {
            _context = context;
            _ServiciosService = ServiciosService; // es necsario colocar en el constructor 
        }
        // GET: api/<ServiciosController>
        [HttpGet] // protege las URLS ERROR 401 NO AUTORIZADO
        public async Task<ActionResult<IEnumerable<Servicios>>> Get()
        {
            return Ok(await _ServiciosService.GetAll()); // solamente va llamar al servicio de Servicios

        }


        // GET api/<ServiciosController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Servicios>> GetById(int id)
        {
            return Ok(await _ServiciosService.GetById(id));
        }

        // POST api/<ServiciosController>
        [HttpPost]
        public async Task<IActionResult> Post(Servicios pais)
        {
            return Ok(await _ServiciosService.Create(pais));
        }

        // PUT api/<ServiciosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Servicios pais)
        {
            return Ok(await _ServiciosService.Update(pais));
        }

        // DELETE api/<ServiciosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _ServiciosService.Delete(id);
            return Ok("{message:Deleted}");
        }
    }
}
