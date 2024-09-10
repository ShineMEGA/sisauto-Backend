using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.interfaces;
/*
 * se hara cargo del contexto (base de datos)
 * inyecta el tema de contexto, se encragara de hacer todos los manejos de la BD
 */
namespace Repository
{
    public class PaisesRepository : iRepository<Paises> // implementar los metodos de la interfaz 
    {
        private readonly SisautoContext _context;
        public PaisesRepository(SisautoContext context)
        {
            _context = context;
        }

        public async Task<Paises> Create(Paises entity)
        {
            _context.Paises.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Paises> Delete(int id)
        {
            var entity = await _context.Paises.FindAsync(id);
            if (entity != null)
            {
                _context.Paises.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
                return null;
        }
          

        public async Task<List<Paises>> GetAll() // se va encragar de hacer la peticion a la base de datos
        {
            //List<Paises> paises = _context.Paises.ToList();

            return await _context.Paises.ToListAsync();

        }

        public async Task<Paises> GetByid(int id)
        {
            return await (_context.Paises.FindAsync(id));
        }
        public async Task<Paises> Update(Paises entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    } 
}
