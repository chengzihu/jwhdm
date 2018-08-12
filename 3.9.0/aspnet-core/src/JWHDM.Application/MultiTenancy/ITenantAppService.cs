using Abp.Application.Services;
using Abp.Application.Services.Dto;
using JWHDM.MultiTenancy.Dto;

namespace JWHDM.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
