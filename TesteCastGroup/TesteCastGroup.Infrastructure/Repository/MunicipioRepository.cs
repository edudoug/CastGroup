using RestSharp;
using TesteCastGroup.Domain.Repository;

namespace TesteCastGroup.Infrastructure.Repository
{
    public class MunicipioRepository : IRepository<string>
    {
        public MunicipioRepository() { }

        public async Task<string> Get()
        {
            var client = new RestClient("http://viacep.com.br/ws/01001000/");

            var request = new RestRequest("json", Method.Get);
            var response = await client.GetAsync(request);

            return response.Content;
        }
    }
}
