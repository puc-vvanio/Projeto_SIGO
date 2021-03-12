using SIGO.Normas.Domain.Entities;
using SIGO.Normas.Domain.Interfaces;
using SIGO.Normas.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Service.Services
{
    public class NormaService : IServiceNorma
    {
        private readonly IUnitOfWork _unitOfWork;

        public NormaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Norma> Salvar(Norma norma)
        {
            try
            {
                await _unitOfWork.Normas.Salvar(norma);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return norma;
        }

        public async Task Atualizar(Norma norma)
        {
            try
            {
                _unitOfWork.Normas.Atualizar(norma);
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
                await _unitOfWork.Normas.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Norma> ObterNorma(int id)
        {
            try
            {
                return await _unitOfWork.Normas.ObterNorma(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Norma>> ObterNormas()
        {
            try
            {
                return await _unitOfWork.Normas.ObterNormas();
            }
            catch
            {
                throw;
            }
        }
    }
}
