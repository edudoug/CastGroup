using TesteCastGroup.Domain.Model;

namespace TesteCastGroup.Domain.Service.Interface
{
    public interface IContaService
    {
        public Conta Incluir(ContaDTO obj);
        public Conta Alterar(Conta conta);
        public bool Excluir(int id);
        public IEnumerable<Conta> Listar();
        public Conta Obter(int id);
    }
}
