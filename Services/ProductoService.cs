using ProductosAPI.Models;
using ProductosAPI.Repositories;

namespace ProductosAPI.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Producto>> ObtenerTodosAsync()=>
            await _repository.ObtenerTodoAsync();

        public async Task<Producto> ObtenerTodosAsync(int id) =>
            await _repository.ObtenerPorIdAsync(id);

        public async Task CrearAsync(Producto producto)=>
            await _repository.CrearAsync(producto);

        public async Task ActualizarAsync(Producto producto)=>
            await _repository.ActualizarAsync(producto);

        public async Task EliminarAsync(int id)=>
            await _repository.EliminarAsync(id);
      
    }
}
