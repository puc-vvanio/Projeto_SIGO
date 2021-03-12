using SIGO.Autenticacao.Domain.Interfaces.Repository;
using System;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
        Task<int> CommitAsync();

        IRepositoryUsuario Usuarios { get; }
    }
}
