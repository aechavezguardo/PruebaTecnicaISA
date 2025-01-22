using Application.Services;
using Domain.Entities;
using Domain.Interfaces;
using Moq;

namespace Test
{
    public class ProveedorServiceTests
    {
        [Fact]
        public async Task GetAllProveedoresAsync_ReturnsList()
        {
            var mockRepo = new Mock<IProveedorRepository>();
            mockRepo.Setup(repo => repo.GetAllProveedoresAsync()).ReturnsAsync(new List<Proveedor>());
            var service = new ProveedorService(mockRepo.Object);

            var result = await service.GetAllProveedoresAsync();

            Assert.NotNull(result);
            Assert.IsType<List<Proveedor>>(result);
        }
    }
}