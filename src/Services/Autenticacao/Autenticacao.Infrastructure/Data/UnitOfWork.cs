using SIGO.Autenticacao.Domain.Interfaces;
using SIGO.Autenticacao.Domain.Interfaces.Repository;
using SIGO.Autenticacao.Infrastructure.CrossCutting;
using SIGO.Autenticacao.Infrastructure.Data.Context;
using SIGO.Autenticacao.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace SIGO.Autenticacao.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IRepositoryUsuario Usuarios { get; set; }

        public UnitOfWork(MySqlContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;

            Usuarios = new UsuarioRepository(_context, _dapperDbConnection);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
