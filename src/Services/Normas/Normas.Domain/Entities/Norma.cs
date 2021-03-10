using SIGO.Normas.Domain.Enums;

namespace SIGO.Normas.Domain.Entities
{
    public class Norma : BaseEntity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string NomeArquivo { get; set; }

        public TipoNorma Tipo { get; set; } = TipoNorma.Nacional;

        public StatusNorma Status { get; set; } = StatusNorma.Vigor;
    }
}
