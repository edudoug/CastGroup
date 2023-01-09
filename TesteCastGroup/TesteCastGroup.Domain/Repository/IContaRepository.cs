using TesteCastGroup.Domain.Model;

namespace TesteCastGroup.Domain.Repository
{
    public interface IContaRepository
    {
        public Conta Incluir(Conta conta);
        public Conta Alterar(Conta conta);
        public bool Excluir(int id);
        public IEnumerable<Conta> Listar();
        public Conta Obter(int id);
    }
}
