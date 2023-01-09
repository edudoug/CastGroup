using TesteCastGroup.Domain.Repository;
using TesteCastGroup.Domain.Service.Interface;

namespace TesteCastGroup.Domain.Service
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IRepository<string> _municipioRepository;
        public MunicipioService(IRepository<string> municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }
        public async Task<string> Get()
        {
            return await _municipioRepository.Get();
        }
    }
}
