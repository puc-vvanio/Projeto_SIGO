using SIGO.Consultorias.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces.Repository
{
    public interface IRepositoryContrato
    {
        Task Salvar(Contrato contrato);

        void Atualizar(Contrato contrato);

        Task Excluir(int id);

        Task<Contrato> ObterContrato(int id);

        Task<List<Contrato>> ObterContratos();
    }
}
