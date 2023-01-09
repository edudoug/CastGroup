using System.ComponentModel.DataAnnotations;

namespace TesteCastGroup.Domain.Model
{
    public class Conta
    {
        [Key]
        public int ContaId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
