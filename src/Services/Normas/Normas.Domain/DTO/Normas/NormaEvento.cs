using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.Normas.Domain.DTO.Normas
{
    public class NormaEvento
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short Sistema { get; set; }
        public int TipoEventoID { get; set; }
    }
}
