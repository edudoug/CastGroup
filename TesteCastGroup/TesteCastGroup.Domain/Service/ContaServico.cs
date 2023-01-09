using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteCastGroup.Domain.Model;
using TesteCastGroup.Domain.Repository;
using TesteCastGroup.Domain.Service.Interface;

namespace TesteCastGroup.Domain.Service
{
    public class ContaServico : IContaService
    {
        private readonly IContaRepository _contaRepository;
        public ContaServico(IContaRepository contaRepository) { _contaRepository = contaRepository; }
        public Conta Alterar(Conta conta)
        {
            Conta contaAlterar = Obter(conta.ContaId);

            if (contaAlterar == null)
                return null;

            return _contaRepository.Alterar(conta);
        }

        public bool Excluir(int id)
        {
            return _contaRepository.Excluir(id);
        }

        public Conta Incluir(ContaDTO conta)
        {
            return _contaRepository.Incluir(new Conta() { Nome = conta.Nome, Descricao = conta.Descricao });
        }

        public IEnumerable<Conta> Listar()
        {
            //List<ContaDTO> retorno = new List<ContaDTO>();
            //var contas = _contaRepository.Listar();
            //foreach (var item in contas)
            //{
            //    ContaDTO conta = new ContaDTO();
            //    conta.Nome = item.Nome;
            //    conta.Descricao = item.Descricao;
            //    retorno.Add(conta);
            //}

            //return retorno;
            return _contaRepository.Listar();
        }

        public Conta Obter(int id)
        {
            return _contaRepository.Obter(id);
        }
    }
}
