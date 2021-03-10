using System;

namespace SIGO.ProcessoIndustrial.Infrastructure.CrossCutting
{
    public interface IDapperDbConnection : IDisposable
    {
        void OpenConnection();
    }
}
