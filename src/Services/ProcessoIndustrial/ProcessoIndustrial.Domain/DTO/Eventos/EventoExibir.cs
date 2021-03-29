using System;

namespace SIGO.ProcessoIndustrial.Domain.DTO.Eventos
{
    public class EventoExibir
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string Sistema { get; set; }

        public int TipoEventoID { get; set; }

        public string TipoEvento { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataAtualizacao { get; set; }
    }
}
