using Newtonsoft.Json;
using SIGO.Normas.Domain.DTO.Normas;
using SIGO.Normas.Infrastructure.CrossCutting;
using SIGO.Normas.Domain.Interfaces.Services;
using System.Threading.Tasks;

namespace SIGO.Normas.Service.Services
{
    public class RepositorioExternoService : SimpleHttpClient, IServiceRepositorioExterno
    {
        public async Task<NormaInfo> GetNormaInfo(string id, string url)
        {
            string result = await GetRequest(url + "?normas={id}");
            return JsonConvert.DeserializeObject<NormaInfo>(result);
        }
    }
}
