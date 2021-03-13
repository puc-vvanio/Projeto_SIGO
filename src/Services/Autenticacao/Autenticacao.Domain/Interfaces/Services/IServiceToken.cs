using SIGO.Autenticacao.Domain.Entities;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceToken
    {
        string GerarToken(Usuario usuario);
    }
}
