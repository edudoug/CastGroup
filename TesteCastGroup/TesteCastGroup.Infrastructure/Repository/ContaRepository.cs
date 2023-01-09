using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TesteCastGroup.Domain.Model;
using TesteCastGroup.Domain.Repository;
using TesteCastGroup.Domain.Service;
using TesteCastGroup.Infrastructure.Context;

namespace TesteCastGroup.Infrastructure.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly DatabaseContext _context;
        //private readonly IMapper _mapper;
        public ContaRepository(DatabaseContext context)
        //IMapper mapper)
        {
            _context = context;
            //_mapper = mapper;
        }

        public Conta Alterar(Conta conta)
        {
            var contaAlt = Obter(conta.ContaId);
            contaAlt.Nome = conta.Nome;
            contaAlt.Descricao = conta.Descricao;

            _context.Update(contaAlt);
            _context.SaveChanges();
            return contaAlt;
        }

        public bool Excluir(int id)
        {
            var conta = Obter(id);
            if (conta == null)
                return false;

            _context.Remove(conta);
            _context.SaveChanges();
            return true;

        }

        public Conta Incluir(Conta conta)
        {
            _context.Add(conta);
            _context.SaveChanges();
            return conta;
        }

        public IEnumerable<Conta> Listar()
        {
            return _context.Contas.ToList();
        }

        public Conta Obter(int id)
        {
            return _context.Contas.Where(c => c.ContaId == id).FirstOrDefault();
        }
    }
}
