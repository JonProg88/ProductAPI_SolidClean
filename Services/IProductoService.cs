using ProductosAPI.Models;

namespace ProductosAPI.Services
{
    /// <summary>
    /// Interfaz que define la logica de negocio de los productos
    /// </summary>
    public interface IProductoService
    {
        Task<IEnumerable<Producto>> ObtenerTodosAsync();
        Task<Producto> ObtenerTodosAsync(int id);
        Task CrearAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
