using System;

namespace SIGO.Normas.Domain.DTO.Normas
{
    public class NormasExibir
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string NomeArquivo { get; set; }

        public string Tipo { get; set; }

        public string Status { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
