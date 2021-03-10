using System;

namespace SIGO.Autenticacao.Infrastructure.CrossCutting
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
