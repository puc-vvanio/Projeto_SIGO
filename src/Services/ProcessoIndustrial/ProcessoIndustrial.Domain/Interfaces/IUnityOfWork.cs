using SIGO.ProcessoIndustrial.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

    }
}
