using SIGO.ProcessoIndustrial.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Domain.Interfaces.Services
{
    public interface IServiceEvento
    {
        Task<Evento> Salvar(Evento evento);

        Task Atualizar(Evento evento);

        Task Excluir(int id);

        Task<Evento> ObterEvento(int id);

        Task<Evento> ObterUltimoEvento(int tipoEventoId);

        Task<List<Evento>> ObterEventos();
    }
}