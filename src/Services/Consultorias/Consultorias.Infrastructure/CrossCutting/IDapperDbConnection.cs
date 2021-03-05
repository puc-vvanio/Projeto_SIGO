using System;

namespace SIGO.Consultorias.Infrastructure.CrossCutting
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
