using SIGO.Autenticacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Repository
{
    public interface IRepositoryAutenticacao
    {
        Task Salvar(Autenticacao autenticacao);

        void Atualizar(Autenticacao autenticacao);

        Task Excluir(int id);

        Task<Autenticacao> ObterAutenticacao(int id);

        Task<List<Autenticacao>> ObterAutenticacao();
    }
}
