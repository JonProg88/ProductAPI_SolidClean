using Microsoft.AspNetCore.Mvc;
using ProductosAPI.Models;
using ProductosAPI.Services;

namespace ProductosAPI.Controllers
{
    /// <summary>
    /// Controlador principal para exponer los endpoints de productos
    /// </summary>
    /// 
    [ApiController]
    [Route("api/controller")]
    public class ProductosController : Controller
    {
        private readonly IProductoService _service;

        public ProductosController(IProductoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var productos = await _service.ObtenerTodosAsync();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var producto = await _service.ObtenerTodosAsync(id);
            if(producto == null) return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Producto producto)
        {
            await _service.CrearAsync(producto);
            return CreatedAtAction(nameof(ObtenerPorId), new {id = producto.Id}, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Actualizar(int id, Producto producto)
        {
            if(id != producto.Id) return BadRequest();
            await _service.ActualizarAsync(producto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }

    }
}
