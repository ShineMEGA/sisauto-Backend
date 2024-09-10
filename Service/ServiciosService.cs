using DB.Models;
using Repository;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiciosService : IService<Servicios>
    {
        private readonly ServiciosRepository _serviciosRepository; // utiliza servicios ServiciosRepository y estos deben de ser registrados en el Program.cs (todos los servicios se deben registrar)
        public ServiciosService(ServiciosRepository serviciosRepository)
        {
            _serviciosRepository = serviciosRepository;
        }
        public async Task<Servicios> Create(Servicios entity)
        {
            return await _serviciosRepository.Create(entity);
        }

        public async Task<Servicios> Delete(int id)
        {
            return await _serviciosRepository.Delete(id);
        }

        public async Task<List<Servicios>> GetAll() // solamente va llamar al repocitorio de servicios
        {
            return await _serviciosRepository.GetAll();
        }

        public async Task<Servicios> GetById(int id)
        {
            return await _serviciosRepository.GetByid(id);
        }

        public async Task<Servicios> Update(Servicios entity)
        {
            return await _serviciosRepository.Update(entity);
        }
    }
}
