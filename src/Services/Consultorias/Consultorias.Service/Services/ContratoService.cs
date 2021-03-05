using SIGO.Consultorias.Domain.Entities;
using SIGO.Consultorias.Domain.Interfaces;
using SIGO.Consultorias.Domain.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Service.Services
{
    class ContratoService : IServiceContrato
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContratoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Contrato> Salvar(Contrato contrato)
        {
            try
            {
                await _unitOfWork.Contratos.Salvar(contrato);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }

            return contrato;
        }

        public async Task Atualizar(Contrato contrato)
        {
            try
            {
                _unitOfWork.Contratos.Atualizar(contrato);
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
                await _unitOfWork.Contratos.Excluir(id);
                await _unitOfWork.CommitAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Contrato> ObterContrato(int id)
        {
            var contrato = new Contrato();

            try
            {
                contrato = await _unitOfWork.Contratos.ObterContrato(id);
            }
            catch
            {
                throw;
            }

            return contrato;
        }

        public async Task<List<Contrato>> ObterContratos()
        {
            try
            {
                return await _unitOfWork.Contratos.ObterContratos();
            }
            catch
            {
                throw;
            }
        }
    }
}
