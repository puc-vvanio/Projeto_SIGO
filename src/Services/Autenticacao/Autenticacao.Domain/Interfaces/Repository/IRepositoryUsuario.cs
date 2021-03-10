using SIGO.Autenticacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Repository
{
    public interface IRepositoryUsuario
    {
        Task Salvar(Usuario usuario);

        void Atualizar(Usuario usuario);

        Task Excluir(int id);

        Task<Usuario> ObterUsuario(int id);

        Task<List<Usuario>> ObterUsuarios();
    }
}
