using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Services
{
    public interface IServiceContrato
    {
        Task<Contrato> Salvar(Contrato contrato);

        Task Atualizar(Contrato contrato);

        Task Excluir(int id);

        Task<Contrato> ObterContrato(int id);

        Task<List<Contrato>> ObterContratos();
    }
}
