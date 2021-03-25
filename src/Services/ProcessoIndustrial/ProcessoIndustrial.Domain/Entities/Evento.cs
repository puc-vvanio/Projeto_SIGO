using SIGO.ProcessoIndustrial.Domain.Enums;

namespace SIGO.ProcessoIndustrial.Domain.Entities
{
    public class Evento : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Sistema Sistema { get; set; } = Sistema.SIGO_Processo_Industrial;
        public int TipoEventoID { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }
    }
}
