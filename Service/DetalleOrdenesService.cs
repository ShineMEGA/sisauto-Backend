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
    public class DetalleOrdenesService : IService<DetalleOrdenes>
    {
        private readonly DetalleOrdenesRepository _detalleOrdenesRepository; // utiliza detalleOrdenes DetalleOrdenesRepository y estos deben de ser registrados en el Program.cs (todos los servicios se deben registrar)
        public DetalleOrdenesService(DetalleOrdenesRepository detalleOrdenesRepository)
        {
            _detalleOrdenesRepository = detalleOrdenesRepository;
        }
        public async Task<DetalleOrdenes> Create(DetalleOrdenes entity)
        {
            return await _detalleOrdenesRepository.Create(entity);
        }

        public async Task<DetalleOrdenes> Delete(int id)
        {
            return await _detalleOrdenesRepository.Delete(id);
        }

        public async Task<List<DetalleOrdenes>> GetAll() // solamente va llamar al repocitorio de detalleOrdenes
        {
            return await _detalleOrdenesRepository.GetAll();
        }

        public async Task<DetalleOrdenes> GetById(int id)
        {
            return await _detalleOrdenesRepository.GetByid(id);
        }

        public async Task<DetalleOrdenes> Update(DetalleOrdenes entity)
        {
            return await _detalleOrdenesRepository.Update(entity);
        }
    }
}
