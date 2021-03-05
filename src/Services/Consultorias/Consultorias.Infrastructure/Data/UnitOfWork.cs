using SIGO.Consultorias.Domain.Interfaces;
using SIGO.Consultorias.Domain.Interfaces.Repository;
using SIGO.Consultorias.Infrastructure.CrossCutting;
using SIGO.Consultorias.Infrastructure.Data.Context;
using SIGO.Consultorias.Infrastructure.Data.Repository;
using System.Threading.Tasks;

namespace SIGO.Consultorias.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MySqlContext _context;
        private readonly IDapperDbConnection _dapperDbConnection;

        public IRepositoryContrato Contratos { get; set; }
        public IRepositoryConsultoria Consultorias { get; set; }

        public UnitOfWork(MySqlContext context, IDapperDbConnection dapperDbConnection)
        {
            _context = context;
            _dapperDbConnection = dapperDbConnection;
            //_dapperDbConnection.OpenConnection();

            Contratos = new ContratoRepository(_context, _dapperDbConnection);
            Consultorias = new ConsultoriaRepository(_context, _dapperDbConnection);
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
