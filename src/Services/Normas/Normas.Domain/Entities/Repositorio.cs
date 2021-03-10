namespace SIGO.Normas.Domain.Entities
{
    public class Repositorio : BaseEntity
    {

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string URL_API { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }
    }
}
