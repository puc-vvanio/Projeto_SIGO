using SIGO.Normas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces.Repository
{
    public interface IRepositoryRepositorio
    {
        Task Salvar(Repositorio repositorio);

        void Atualizar(Repositorio repositorio);

        Task Excluir(int id);

        Task<Repositorio> ObterRepositorio(int id);

        Task<List<Repositorio>> ObterRepositorios();
    }
}
