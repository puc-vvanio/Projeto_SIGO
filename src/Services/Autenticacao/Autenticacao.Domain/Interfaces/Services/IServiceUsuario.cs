using SIGO.Autenticacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceUsuario
    {
        Task<Usuario> Salvar(Usuario usuario);

        Task Atualizar(Usuario usuario);

        Task Excluir(int id);

        Task<Usuario> ObterUsuario(int id);

        Task<List<Usuario>> ObterUsuarios();
    }
}
