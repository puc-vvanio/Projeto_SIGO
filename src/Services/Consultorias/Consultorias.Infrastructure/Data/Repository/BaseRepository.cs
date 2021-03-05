using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using SIGO.Consultorias.Infrastructure.CrossCutting;

namespace SIGO.Consultorias.Infrastructure.Data.Repository
{
    public abstract class BaseRepository
    {
        protected MySqlConnection DapperConnection = null;
        protected DbContext Context = null;

        public BaseRepository(IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
        }

        public BaseRepository(DbContext context, IDapperDbConnection dapperDbConnection)
        {
            DapperConnection = ((DapperDbConnection)dapperDbConnection).GetConnection();
            Context = context;
        }
    }
}
