using SIGO.ProcessoIndustrial.Domain.Interfaces;
using SIGO.ProcessoIndustrial.Domain.Interfaces.Repository;
using SIGO.ProcessoIndustrial.Infrastructure.CrossCutting;
using SIGO.ProcessoIndustrial.Infrastructure.Data.Context;
using SIGO.ProcessoIndustrial.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace SIGO.ProcessoIndustrial.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IRepositoryEvento Eventos { get; set; }
        public IRepositoryTipoEvento TiposEventos { get; set; }

        public UnitOfWork(MySqlContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;

            Eventos = new EventoRepository(_context, _dapperDbConnection);
            TiposEventos = new TipoEventoRepository(_context, _dapperDbConnection);
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
