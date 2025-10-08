using Moq;
using ProductosAPI.Models;
using ProductosAPI.Repositories;
using ProductosAPI.Services;
using Xunit;

namespace ProductosAPI.Test
{
    /// <summary>
    /// Prueba unitaria simple para validar que se cumpla el flujo de creacion de producto
    /// </summary>
    public class ProductoServiceTests
    {
        [Fact]
        public async Task CrearAsync_DeberiaLlamarAlRepositorio()
        {
            // Arrange
            var mockRepo = new Mock<IProductoRepository>();
            var service = new ProductoService(mockRepo.Object);

            var producto = new Producto { Id = 1, Nombre = "Laptop", Precio = 25000, Stock = 5 };

            // Act
            await service.CrearAsync(producto);

            // Assert
            mockRepo.Verify(r => r.CrearAsync(It.IsAny<Producto>()), Times.Once);

        }


    }
}
