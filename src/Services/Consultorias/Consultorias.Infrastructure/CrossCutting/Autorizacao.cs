using System.Text;

namespace SIGO.Consultorias.Domain
{
    public static class Autorizacao
    {
        public static byte[] Chave = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");

        public class Grupo
        {
            public const string ADMIN = nameof(ADMIN);
            public static string DIRETOR = nameof(DIRETOR);
            public static string GERENTE = nameof(GERENTE);
        }
    }
}
