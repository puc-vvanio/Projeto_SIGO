using SIGO.Autenticacao.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces.Services
{
    public interface IServiceAutenticacao
    {
        Task<Autenticacao> Salvar(Autenticacao autenticacao);

        Task Atualizar(Autenticacao autenticacao);

        Task Excluir(int id);

        Task<Autenticacao> ObterAutenticacao(int id);

        Task<List<Autenticacao>> ObterAutenticacao();
    }
}
