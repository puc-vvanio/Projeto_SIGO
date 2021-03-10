using SIGO.Normas.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IRepositoryRepositorio Repositorios { get; }
        IRepositoryNorma Normas { get; }
    }
}
