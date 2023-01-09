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
    public class UnitTestContaServicoDeletar
    {
        [Fact]
        public void AdicionarConta()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProider = serviceCollection.BuildServiceProvider();

            var contaService = serviceProider.GetService<IContaService>();

            // Arrange
            int id = 1;

            // Act
            var teste = contaService.Excluir(id);

            // Assert
            Assert.Equal(true, teste);

        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaServico>()
                .AddScoped<IContaRepository, ContaRepository>()
                .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("teste"));
        }
    }
}