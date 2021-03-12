using SIGO.ProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Domain.Interfaces.Services
{
    public interface IServiceTipoEvento
    {
        Task<TipoEvento> Salvar(TipoEvento tipoEvento);

        Task Atualizar(TipoEvento tipoEvento);

        Task Excluir(int id);

        Task<TipoEvento> ObterTipoEvento(int id);

        Task<List<TipoEvento>> ObterTiposEventos();
    }
}