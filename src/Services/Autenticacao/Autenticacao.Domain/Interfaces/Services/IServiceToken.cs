using SIGO.Autenticacao.Domain.Entities;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceToken
    {
        string GerarToken(Usuario usuario);
    }
}
