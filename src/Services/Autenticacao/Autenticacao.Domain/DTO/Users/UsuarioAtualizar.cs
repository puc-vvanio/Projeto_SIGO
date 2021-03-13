using SIGO.Autenticacao.Domain.Enums;

namespace SIGO.Autenticacao.Domain.Models.Users
{
    public class UsuarioAtualizar
    {
        public string Nome { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public PerfilUsuario Perfil { get; set; } = PerfilUsuario.Colaborador;

        public StatusUsuario Status { get; set; } = StatusUsuario.Ativo;
    }
}
