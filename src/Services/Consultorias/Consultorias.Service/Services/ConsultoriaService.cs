using SIGO.Consultorias.Domain.Entities;
using SIGO.Consultorias.Domain.Interfaces;
using SIGO.Consultorias.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Service.Services
{
    public class ConsultoriaService : IServiceConsultoria
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Consultoria> Salvar(Consultoria consultoria)
        {
            try
            {
                await _unitOfWork.Consultorias.Salvar(consultoria);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return consultoria;
        }

        public async Task Atualizar(Consultoria consultoria)
        {
            try
            {
                _unitOfWork.Consultorias.Atualizar(consultoria);
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
                await _unitOfWork.Consultorias.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Consultoria> ObterConsultoria(int id)
        {
            var consultoria = new Consultoria();

            try
            {
                consultoria = await _unitOfWork.Consultorias.ObterConsultoria(id);
            }
            catch
            {
                throw;
            }

            return consultoria;
        }

        public async Task<List<Consultoria>> ObterConsultorias()
        {
            try
            {
                return await _unitOfWork.Consultorias.ObterConsultorias();
            }
            catch
            {
                throw;
            }
        }
    }
}
