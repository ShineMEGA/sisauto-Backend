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
    
    public class ClientesController : ControllerBase
    {
        private readonly SisautoContext _context; // inyeccion de dependencias _""
        private readonly ClientesService _clientesService; //inyectar el servicio 
        public ClientesController(SisautoContext context, ClientesService clientesService) //ctor + tab
        {
            _context = context;
            _clientesService = clientesService; // es necsario colocar en el constructor 
        }
        // GET: api/<ClientesController>
        [HttpGet] // protege las URLS ERROR 401 NO AUTORIZADO
        public async Task<ActionResult<IEnumerable<Clientes>>> Get()
        {
            return Ok(await _clientesService.GetAll()); // solamente va llamar al servicio de clientes

        }


        // GET api/<ClientesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clientes>> GetById(int id)
        {
            return Ok(await _clientesService.GetById(id));
        }

        // POST api/<ClientesController>
        [HttpPost]
        public async Task<IActionResult> Post(Clientes pais)
        {
            return Ok(await _clientesService.Create(pais));
        }

        // PUT api/<ClientesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Clientes pais)
        {
            return Ok(await _clientesService.Update(pais));
        }

        // DELETE api/<ClientesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clientesService.Delete(id);
            return Ok("{message:Deleted}");
        }
    }
}
