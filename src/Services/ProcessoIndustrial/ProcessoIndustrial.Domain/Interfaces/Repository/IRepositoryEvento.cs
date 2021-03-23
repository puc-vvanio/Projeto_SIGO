using SIGO.ProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Domain.Interfaces.Repository
{
    public interface IRepositoryEvento
    {
        Task Salvar(Evento evento);

        void Atualizar(Evento evento);

        Task Excluir(int id);

        Task<Evento> ObterEvento(int id);

        Task<Evento> ObterUltimoEvento(int tipoEventoId);

        Task<List<Evento>> ObterEventos();
    }
}
