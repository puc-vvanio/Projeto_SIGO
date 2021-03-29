using SIGO.Normas.Domain.DTO.Normas;

namespace SIGO.Normas.Infrastructure.CrossCutting.EventBus.Senders
{
    public interface INormaUpdateSender
    {
        void EnviarNormaAtualizada(NormaEvento normaEvento);
    }
}
