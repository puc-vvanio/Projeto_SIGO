using System.Collections.Generic;

namespace SIGO.Consultorias.Domain.Entities
{
    public class Consultoria : BaseEntity
    {
        public string Nome { get; set; }

        public string Descricao { get; set; }

        public List<Contrato> Contratos { get; set; }
    }
}
