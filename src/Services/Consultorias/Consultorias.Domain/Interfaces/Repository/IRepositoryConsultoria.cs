using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Repository
{
    public interface IRepositoryConsultoria
    {
        Task Salvar(Consultoria consultoria);

        void Atualizar(Consultoria consultoria);

        Task Excluir(int id);

        Task<Consultoria> ObterConsultoria(int id);

        Task<List<Consultoria>> ObterConsultorias();
    }
}
