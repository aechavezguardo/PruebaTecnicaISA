using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly IMongoCollection<Proveedor> _proveedores;

        public ProveedorRepository(IMongoDatabase database)
        {
            _proveedores = database.GetCollection<Proveedor>("Proveedores");
        }

        public async Task<Proveedor> GetProveedorByIdAsync(string id)
        {
            return await _proveedores.Find(p => p.Id == new MongoDB.Bson.ObjectId(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Proveedor>> GetAllProveedoresAsync()
        {
            return await _proveedores.Find(p => true).ToListAsync();
        }

        public async Task CreateProveedorAsync(Proveedor proveedor)
        {
            await _proveedores.InsertOneAsync(proveedor);
        }

        public async Task UpdateProveedorAsync(Proveedor proveedor)
        {
            await _proveedores.ReplaceOneAsync(p => p.Id == proveedor.Id, proveedor);
        }

        public async Task DeleteProveedorAsync(string id)
        {
            await _proveedores.DeleteOneAsync(p => p.Id == new MongoDB.Bson.ObjectId(id));
        }
    }
}
