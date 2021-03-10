using System;

namespace SIGO.Normas.Infrastructure.CrossCutting
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
