
namespace SIGO.ProcessoIndustrial.Domain.Entities
{
    public class EventoMessage
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public short Sistema { get; set; }
        public int TipoEventoID { get; set; }
    }
}
