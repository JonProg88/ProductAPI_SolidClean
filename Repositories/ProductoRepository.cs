using Microsoft.EntityFrameworkCore;
using ProductosAPI.Data;
using ProductosAPI.Models;

namespace ProductosAPI.Repositories
{
    /// <summary>
    /// Implementacion del repositorio que accede directamente
    /// </summary>
    public class ProductoRepository :IProductoRepository
    {
        private readonly AppDbContext _context;

        public ProductoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodoAsync() =>
            await _context.Productos.AsNoTracking().ToListAsync();


        public async Task<Producto> ObtenerPorIdAsync(int id) =>
            await _context.Productos.FindAsync(id);

        public async Task CrearAsync(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarAsync(Producto producto)
        {
            _context.Productos.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarAsync(int id)
        {
            var entity = await _context.Productos.FindAsync(id);
            if (entity == null) return;

            _context.Productos.Remove(entity);
            await _context.SaveChangesAsync();
        }

     
    }
}
