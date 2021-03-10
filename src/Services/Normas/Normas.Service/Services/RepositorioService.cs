using SIGO.Normas.Domain.Entities;
using SIGO.Normas.Domain.Interfaces;
using SIGO.Normas.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Normas.Service.Services
{
    public class RepositorioService : IServiceRepositorio
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositorioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Repositorio> Salvar(Repositorio repositorio)
        {
            try
            {
                await _unitOfWork.Repositorios.Salvar(repositorio);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return repositorio;
        }

        public async Task Atualizar(Repositorio repositorio)
        {
            try
            {
                _unitOfWork.Repositorios.Atualizar(repositorio);
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
                await _unitOfWork.Repositorios.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Repositorio> ObterRepositorio(int id)
        {
            var repositorio = new Repositorio();

            try
            {
                repositorio = await _unitOfWork.Repositorios.ObterRepositorio(id);
            }
            catch
            {
                throw;
            }

            return repositorio;
        }

        public async Task<List<Repositorio>> ObterRepositorios()
        {
            try
            {
                return await _unitOfWork.Repositorios.ObterRepositorios();
            }
            catch
            {
                throw;
            }
        }
    }
}
