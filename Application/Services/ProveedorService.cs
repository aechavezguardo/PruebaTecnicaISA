using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<Proveedor> GetProveedorByIdAsync(string id)
        {
            return await _proveedorRepository.GetProveedorByIdAsync(id);
        }

        public async Task<IEnumerable<Proveedor>> GetAllProveedoresAsync()
        {
            return await _proveedorRepository.GetAllProveedoresAsync();
        }

        public async Task CreateProveedorAsync(Proveedor proveedor)
        {
            await _proveedorRepository.CreateProveedorAsync(proveedor);
        }

        public async Task UpdateProveedorAsync(Proveedor proveedor)
        {
            await _proveedorRepository.UpdateProveedorAsync(proveedor);
        }

        public async Task DeleteProveedorAsync(string id)
        {
            await _proveedorRepository.DeleteProveedorAsync(id);
        }
    }
}
