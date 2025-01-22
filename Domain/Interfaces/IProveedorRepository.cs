using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProveedorRepository
    {
        Task<Proveedor> GetProveedorByIdAsync(string id);
        Task<IEnumerable<Proveedor>> GetAllProveedoresAsync();
        Task CreateProveedorAsync(Proveedor proveedor);
        Task UpdateProveedorAsync(Proveedor proveedor);
        Task DeleteProveedorAsync(string id);
    }
}
