using SIGO.Autenticacao.Domain.Enums;

namespace SIGO.Autenticacao.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public TipoUsuario Tipo { get; set; } = TipoUsuario.Outro;

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int AutenticacaoID { get; set; }

        public Autenticacao Autenticacao { get; set; }
    }
}
