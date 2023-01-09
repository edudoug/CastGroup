using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.Design;
using TesteCastGroup.Domain.Repository;
using TesteCastGroup.Domain.Service;
using TesteCastGroup.Domain.Service.Interface;
using TesteCastGroup.Infrastructure.Context;
using TesteCastGroup.Infrastructure.Repository;
using Xunit;

namespace TestProjectTesteCastGroup
{
    public class UnitTestContaServicoBuscar
    {
        [Fact]
        public void BuscarContas()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProider = serviceCollection.BuildServiceProvider();

            var contaService = serviceProider.GetService<IContaService>();

            // Arrange

            // Act
            var teste = contaService.Listar();

            // Assert
            Assert.Equal("Fulano", teste[0].Nome);
            Assert.Equal("descição Fulano", teste[0].Descricao);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaServico>()
                .AddScoped<IContaRepository, ContaRepository>()
                .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("teste"));
        }
    }
}