using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Services
{
    public interface IServiceContrato
    {
        Task Salvar(Contrato contrato);

        void Atualizar(Contrato contrato);

        Task Excluir(string guid);

        Task<Contrato> ObterContrato(string guid);

        Task<List<Contrato>> ObterContratos();
    }
}
