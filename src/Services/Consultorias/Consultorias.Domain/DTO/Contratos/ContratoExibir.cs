using SIGO.Consultorias.Domain.Entities;
using SIGO.Consultorias.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.Consultorias.Domain.DTO.Contratos
{
    public class ContratoExibir
    {
        public int Id { get; set; }

        public string Tipo { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int ConsultoriaID { get; set; }

        public string Consultoria { get; set; }

        public DateTime dataCriacao { get; set; }

        public DateTime ?dataAtualizacao { get; set; }
    }


    public class ContratoResumo
    {
        public string VigentesTitulo { get; set; }
        public string VigentesDescricao { get; set; }

        public string VencerTitulo { get; set; }
        public string VencerDescricao { get; set; }

        public string VencidosTitulo { get; set; }
        public string VencidosDescricao { get; set; }
    }

}
