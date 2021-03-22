using SIGO.Normas.Domain.DTO.Normas;
using System.Threading.Tasks;

namespace SIGO.Normas.Domain.Interfaces.Services
{
    public interface IServiceRepositorioExterno
    {
        Task<NormaInfo> GetNormaInfo(string id, string url);
    }
}