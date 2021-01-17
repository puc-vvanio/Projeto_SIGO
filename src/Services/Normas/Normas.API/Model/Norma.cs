using System;

namespace Sigo.Normas.API.Model
{
    public class Norma
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public string NomeArquivo { get; set; }
        //public IFormFile FormFile { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimaAtualizacao { get; set; }
    }
}
