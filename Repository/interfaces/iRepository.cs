using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.interfaces
{
    public interface iRepository<T> // "T" REFERENCIA A UNA ENTIDAD QUESE VA REMPLAZAR (MODELO DE LA BASE DE DATOS)
    {
       Task<List<T>> GetAll();
       Task<T> GetByid(int id);
        Task<T>  Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
