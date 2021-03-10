using SIGO.Normas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces.Repository
{
    public interface IRepositoryNorma
    {
        Task Salvar(Norma norma);

        void Atualizar(Norma norma);

        Task Excluir(int id);

        Task<Norma> ObterNorma(int id);

        Task<List<Norma>> ObterNormas();
    }
}
