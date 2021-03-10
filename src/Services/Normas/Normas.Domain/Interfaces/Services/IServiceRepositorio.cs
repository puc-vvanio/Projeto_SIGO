using SIGO.Normas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces.Services
{
    public interface IServiceRepositorio
    {
        Task<Repositorio> Salvar(Repositorio repositorio);

        Task Atualizar(Repositorio repositorio);

        Task Excluir(int id);

        Task<Repositorio> ObterRepositorio(int id);

        Task<List<Repositorio>> ObterRepositorios();
    }
}
