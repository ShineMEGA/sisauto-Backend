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
    public class ServiciosRepository : iRepository<Servicios> // aqui se implenta la interfas 
    {
        private readonly SisautoContext _context;
        public ServiciosRepository(SisautoContext context)
        {
            _context = context;
        }
        public async Task<Servicios> Create(Servicios entity)
        {
            _context.Servicios.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Servicios> Delete(int id)
        {
            var entity = await _context.Servicios.FindAsync(id);
            if (entity != null)
            {
                _context.Servicios.Remove(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<Servicios>> GetAll()
        {
            return await _context.Servicios.ToListAsync();
        }

        public async Task<Servicios> GetByid(int id)
        {
            return await (_context.Servicios.FindAsync(id));
        }

        public async Task<Servicios> Update(Servicios entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
