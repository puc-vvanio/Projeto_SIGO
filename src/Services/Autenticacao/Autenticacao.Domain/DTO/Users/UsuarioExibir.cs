using SIGO.Autenticacao.Domain.Enums;

namespace SIGO.Autenticacao.Domain.Models.Users
{
    public class UsuarioExibir
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public StatusUsuario Status { get; set; }
    }
}
