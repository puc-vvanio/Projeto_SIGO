using SIGO.Autenticacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        Task<Usuario> Autenticar(string email, string senha);

        Task<Usuario> Salvar(Usuario usuario, string senha);

        Task Atualizar(Usuario usuario, string senha = null);

        Task Excluir(int id);

        Task<Usuario> ObterUsuario(int id);

        Task<List<Usuario>> ObterUsuarios();
    }
}
