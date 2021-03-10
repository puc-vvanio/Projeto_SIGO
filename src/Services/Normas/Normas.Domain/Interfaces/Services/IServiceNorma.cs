using SIGO.Normas.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces.Services
{
    public interface IServiceNorma
    {
        Task<Norma> Salvar(Norma norma);

        Task Atualizar(Norma norma);

        Task Excluir(int id);

        Task<Norma> ObterNorma(int id);

        Task<List<Norma>> ObterNormas();
    }
}
