using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.ProcessoIndustrial.Domain.Enums
{
    public enum Sistema : short
    {
        Autenticacao,
        Normas,
        Consultorias,
        Processos_Industriais,
        Logistica,
        Vendas,
        Qualidade,
        Inteligencia,
        Relatorios,
        SIGO = short.MaxValue
    }
}
