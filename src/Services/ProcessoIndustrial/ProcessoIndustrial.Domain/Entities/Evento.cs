namespace SIGO.ProcessoIndustrial.Domain.Entities
{
    public class Evento : BaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int TipoEventoID { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }
    }
}
