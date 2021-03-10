using SIGO.Normas.Domain.Interfaces;
using SIGO.Normas.Domain.Interfaces.Repository;
using SIGO.Normas.Infrastructure.CrossCutting;
using SIGO.Normas.Infrastructure.Data.Context;
using SIGO.Normas.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace SIGO.Normas.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IRepositoryRepositorio Repositorios { get; set; }
        public IRepositoryNorma Normas { get; set; }

        public UnitOfWork(MySqlContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;

            Repositorios = new RepositorioRepository(_context, _dapperDbConnection);
            Normas = new NormaRepository(_context, _dapperDbConnection);
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
