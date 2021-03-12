using SIGO.Autenticacao.Domain.Models.Users;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceToken
    {
        string GerarToken(UsuarioAutenticar usuario);
    }
}
