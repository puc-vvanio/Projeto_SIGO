﻿using SIGO.Consultorias.Domain.Enums;
using System;

namespace SIGO.Consultorias.Domain.Entities
{
    public class Contrato : BaseEntity
    {
        public TipoContrato Tipo { get; set; } = TipoContrato.Outro;

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime? DataInicio { get; set; }

        public DateTime? DataTermino { get; set; }

        public int ConsultoriaID { get; set; }

        public Consultoria Consultoria { get; set; }
    }
}
