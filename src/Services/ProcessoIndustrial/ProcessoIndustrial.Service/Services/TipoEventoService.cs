using SIGO.ProcessoIndustrial.Domain.Entities;
using SIGO.ProcessoIndustrial.Domain.Interfaces;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Service.Services
{
    public class TipoEventoService : IServiceTipoEvento
    {
        private readonly IUnitOfWork _unitOfWork;

        public TipoEventoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TipoEvento> Salvar(TipoEvento tipoEvento)
        {
            try
            {
                await _unitOfWork.TiposEventos.Salvar(tipoEvento);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return tipoEvento;
        }

        public async Task Atualizar(TipoEvento tipoEvento)
        {
            try
            {
                _unitOfWork.TiposEventos.Atualizar(tipoEvento);
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
                await _unitOfWork.TiposEventos.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<TipoEvento> ObterTipoEvento(int id)
        {
            try
            {
                return await _unitOfWork.TiposEventos.ObterTipoEvento(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<TipoEvento>> ObterTiposEventos()
        {
            try
            {
                return await _unitOfWork.TiposEventos.ObterTiposEventos();
            }
            catch
            {
                throw;
            }
        }
    }
}
