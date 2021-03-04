using System;

namespace Sigo.Autenticacao.API.Model
{
    public class Acesso
    {
        public int Id { get; set; }
        public int Id_Usuario { get; set; }
        public string Sistema { get; set; }
        public string Regra { get; set; }
        public int Status { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }


    }
}
