using ProductosAPI.Models;

namespace ProductosAPI.Repositories
{
    /// <summary>
    ///  /// Interfaz del repositorio que define la operaciones con la base de datos
    /// 
    /// </summary>
    public interface IProductoRepository
    {
        Task<IEnumerable<Producto>> ObtenerTodoAsync();
        Task<Producto> ObtenerPorIdAsync(int id);
        Task CrearAsync(Producto producto);
        Task ActualizarAsync(Producto producto);
        Task EliminarAsync(int id);
    }
}
