using SIGO.Consultorias.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IRepositoryContrato Contratos { get; }
        IRepositoryConsultoria Consultorias { get; }
    }
}
