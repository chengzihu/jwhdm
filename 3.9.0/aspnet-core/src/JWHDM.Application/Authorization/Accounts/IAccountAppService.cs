using System.Threading.Tasks;
using Abp.Application.Services;
using JWHDM.Authorization.Accounts.Dto;

namespace JWHDM.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
