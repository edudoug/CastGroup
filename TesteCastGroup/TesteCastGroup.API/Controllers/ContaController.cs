using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.Design;
using TesteCastGroup.Domain.Model;
using TesteCastGroup.Domain.Service.Interface;

namespace TesteCastGroup.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;
        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet(Name = "BuscarContas")]
        public IActionResult Get()
        {
            return Ok(_contaService.Listar());
        }
        [HttpPost(Name = "InserirConta")]
        public IActionResult Post(ContaDTO conta)
        {
            string mensagem = string.Empty;
            if (_contaService.Incluir(conta) != null)
                mensagem = "Conta criada!";
            else
                mensagem = "Conta não criada!";

            return Ok(mensagem);
        }
        [HttpPut(Name = "AtualizarConta")]
        public IActionResult Put(Conta conta)
        {
            string mensagem = string.Empty;
            if (_contaService.Alterar(conta) != null)
                mensagem = "Conta alterada!";
            else
                mensagem = "Conta não alterada";

            return Ok(mensagem);
        }
        [HttpDelete(Name = "DeletarConta")]
        public IActionResult Delete(int id)
        {
            string mensagem = string.Empty;
            if (!_contaService.Excluir(id))
                mensagem = "Conta não deletada!";
            else
                mensagem = "Conta deletada!";

            return Ok(mensagem);
        }
    }
}
