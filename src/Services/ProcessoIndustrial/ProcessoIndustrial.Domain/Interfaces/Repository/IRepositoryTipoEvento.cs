using SIGO.ProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Domain.Interfaces.Repository
{
    public interface IRepositoryTipoEvento
    {
        Task Salvar(TipoEvento tipoEvento);

        void Atualizar(TipoEvento tipoEvento);

        Task Excluir(int id);

        Task<TipoEvento> ObterTipoEvento(int id);

        Task<List<TipoEvento>> ObterTiposEventos();
    }
}
