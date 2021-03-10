using SIGO.Autenticacao.Domain.Entities;
using SIGO.Autenticacao.Domain.Interfaces;
using SIGO.Autenticacao.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Service.Services
{
    public class AutenticacaoService : IServiceAutenticacao
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutenticacaoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Autenticacao> Salvar(Autenticacao autenticacao)
        {
            try
            {
                await _unitOfWork.Autenticacao.Salvar(autenticacao);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return autenticacao;
        }

        public async Task Atualizar(Autenticacao autenticacao)
        {
            try
            {
                _unitOfWork.Autenticacao.Atualizar(autenticacao);
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
                await _unitOfWork.Autenticacao.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Autenticacao> ObterAutenticacao(int id)
        {
            var autenticacao = new Autenticacao();

            try
            {
                autenticacao = await _unitOfWork.Autenticacao.ObterAutenticacao(id);
            }
            catch
            {
                throw;
            }

            return autenticacao;
        }

        public async Task<List<Autenticacao>> ObterAutenticacao()
        {
            try
            {
                return await _unitOfWork.Autenticacao.ObterAutenticacao();
            }
            catch
            {
                throw;
            }
        }
    }
}
