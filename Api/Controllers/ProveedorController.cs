using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Swashbuckle.AspNetCore.Annotations;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        /// <summary>
        /// Obtiene todos los proveedores
        /// </summary>
        /// <returns>Lista de proveedores</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Obtiene todos los proveedores", Description = "Este endpoint permite obtener todos los proveedores registrados.")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _proveedorService.GetAllProveedoresAsync());
        }

        /// <summary>
        /// Obtiene un proveedor por su ID
        /// </summary>
        /// <param name="id">El ID del proveedor</param>
        /// <returns>Un proveedor si se encuentra, o NotFound si no existe</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtiene un proveedor por su ID", Description = "Este endpoint permite obtener un proveedor a partir de su ID.")]

        public async Task<IActionResult> Get(string id)
        {
            var proveedor = await _proveedorService.GetProveedorByIdAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        /// <summary>
        /// Inserta un proveedor
        /// </summary>
        /// <returns>Datos del proveedor insertado</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Insertar un proveedor", Description = "Este endpoint permite insertar un nuevo proveedor.")]
        public async Task<IActionResult> Post(Proveedor proveedor)
        {
            await _proveedorService.CreateProveedorAsync(proveedor);
            return CreatedAtAction(nameof(Get), new { id = proveedor.Id }, proveedor);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Actualizar un proveedor", Description = "Este endpoint permite actualizar la información de un proveedor por su ID.")]
        public async Task<IActionResult> Put(string id, Proveedor proveedor)
        {
            proveedor.Id = new ObjectId(id);
            await _proveedorService.UpdateProveedorAsync(proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Eliminar un proveedor", Description = "Este endpoint permite eliminar un proveedor por su ID.")]
        public async Task<IActionResult> Delete(string id)
        {
            await _proveedorService.DeleteProveedorAsync(id);
            return NoContent();
        }
    }
}
