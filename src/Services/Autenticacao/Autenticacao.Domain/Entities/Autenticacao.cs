using System.Collections.Generic;

namespace SIGO.Autenticacao.Domain.Entities
{
    public class Autenticacao : BaseEntity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<Usuario> Usuarios { get; set; }
    }
}
