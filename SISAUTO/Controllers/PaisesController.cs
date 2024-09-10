using DB;
using DB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SISAUTO.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly SisautoContext _context; // inyeccion de dependencias _""
        private readonly PaisesService _paisesService; //inyectar el servicio 
        public PaisesController(SisautoContext context,PaisesService paisesService) //ctor + tab
        {
            _context = context;
            _paisesService = paisesService; // es necsario colocar en el constructor 
        }
        // GET: api/<PaisesController>
        [HttpGet, Authorize] // protege las URLS ERROR 401 NO AUTORIZADO
        public  async Task<ActionResult<IEnumerable<Paises>>> Get()
        {
            return Ok(await _paisesService.GetAll()); // solamente va llamar al servicio de paises
        }


        // GET api/<PaisesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paises>> GetById(int id)
        {
            return Ok(await _paisesService.GetById(id));
        }

        // POST api/<PaisesController>
        [HttpPost]
        public async Task<IActionResult> Post(Paises pais)
        {
            return Ok(await _paisesService.Create(pais));
        }

        // PUT api/<PaisesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Paises pais)
        {
            return Ok(await _paisesService.Update(pais));
        }

        // DELETE api/<PaisesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _paisesService.Delete(id);
            return Ok("{message:Deleted}");
            
        }
    }
}
