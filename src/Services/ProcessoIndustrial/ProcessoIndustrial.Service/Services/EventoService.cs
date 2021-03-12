using SIGO.ProcessoIndustrial.Domain.Entities;
using SIGO.ProcessoIndustrial.Domain.Interfaces;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Service.Services
{
    public class EventoService : IServiceEvento
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Evento> Salvar(Evento evento)
        {
            try
            {
                await _unitOfWork.Eventos.Salvar(evento);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return evento;
        }

        public async Task Atualizar(Evento evento)
        {
            try
            {
                _unitOfWork.Eventos.Atualizar(evento);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task Excluir(int id)
        {
            try
            {
                await _unitOfWork.Eventos.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Evento> ObterEvento(int id)
        {
            try
            {
                return await _unitOfWork.Eventos.ObterEvento(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Evento>> ObterEventos()
        {
            try
            {
                return await _unitOfWork.Eventos.ObterEventos();
            }
            catch
            {
                throw;
            }
        }
    }
}
