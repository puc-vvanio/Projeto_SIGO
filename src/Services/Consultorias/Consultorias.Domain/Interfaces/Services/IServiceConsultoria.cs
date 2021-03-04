using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Services
{
    public interface IServiceConsultoria
    {
        Task Salvar(Consultoria consultoria);
        void Atualizar(Consultoria consultoria);
        Task Excluir(string guid);
        Task<Consultoria> ObterConsultoria(string guid);
        Task<List<Consultoria>> ObterConsultorias();
    }
}
