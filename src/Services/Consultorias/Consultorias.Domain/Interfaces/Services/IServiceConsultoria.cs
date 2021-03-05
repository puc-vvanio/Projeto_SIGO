using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Services
{
    public interface IServiceConsultoria
    {
        Task<Consultoria> Salvar(Consultoria consultoria);

        Task Atualizar(Consultoria consultoria);

        Task Excluir(int id);

        Task<Consultoria> ObterConsultoria(int id);

        Task<List<Consultoria>> ObterConsultorias();
    }
}
