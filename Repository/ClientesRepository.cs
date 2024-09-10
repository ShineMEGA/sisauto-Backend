using DB;
using DB.Models;
using Microsoft.EntityFrameworkCore;
using Repository.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClientesRepository : iRepository<Clientes> // aqui se implenta la interfas 
    {
        private readonly SisautoContext _context;
        public ClientesRepository(SisautoContext context)
        {
            _context = context;
        }
        public async Task<Clientes> Create(Clientes entity)
        {
            var paisExiste = _context.Paises.Find(entity.PaisID);
            if (paisExiste == null)
            {
                return new Clientes();
            }
            _context.Clientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Clientes> Delete(int id)
        {
            var entity = await _context.Clientes.FindAsync(id);
            if (entity != null)
            {
                _context.Clientes.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Clientes>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Clientes> GetByid(int id)
        {
            return await (_context.Clientes.FindAsync(id));
        }

        public async Task<Clientes> Update(Clientes entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
