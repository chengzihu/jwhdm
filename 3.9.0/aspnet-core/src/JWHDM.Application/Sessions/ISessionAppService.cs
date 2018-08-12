using System.Threading.Tasks;
using Abp.Application.Services;
using JWHDM.Sessions.Dto;

namespace JWHDM.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
