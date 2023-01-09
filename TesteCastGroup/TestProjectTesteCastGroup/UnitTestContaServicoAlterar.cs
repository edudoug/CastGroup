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
    public class UnitTestContaServicoAlterar
    {
        [Fact]
        public void AlterarContas() {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProider = serviceCollection.BuildServiceProvider();

            var contaService = serviceProider.GetService<IContaService>();

            // Arrange
            string nome = "Beltrano";
            string descricao = "descição Beltrano";

            // Act
            var teste = contaService.Alterar(new TesteCastGroup.Domain.Model.ContaDTO() { Nome = nome, Descricao = descricao }, 1);

            // Assert
            Assert.Equal("Beltrano", teste.Nome);
            Assert.Equal("descição Beltrano", teste.Descricao);
            Assert.Equal(1, teste.ContaId);
        }
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IContaService, ContaServico>()
                .AddScoped<IContaRepository, ContaRepository>()
                .AddDbContext<DatabaseContext>(opt => opt.UseInMemoryDatabase("teste"));
        }
    }
}