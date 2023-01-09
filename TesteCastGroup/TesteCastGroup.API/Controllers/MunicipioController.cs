using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteCastGroup.Domain.Model;
using TesteCastGroup.Domain.Service.Interface;

namespace TesteCastGroup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MunicipioController : ControllerBase
    {
        private readonly IMunicipioService _municipioService;

        public MunicipioController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        /// <summary>
        /// Método responsável por retornar um municipio
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "BuscarMunicipio")]
        public IActionResult Get()
        {
            var municipio = _municipioService.Get().Result;
            return Ok(JsonConvert.DeserializeObject<Municipio>(municipio));
        }
    }
}
