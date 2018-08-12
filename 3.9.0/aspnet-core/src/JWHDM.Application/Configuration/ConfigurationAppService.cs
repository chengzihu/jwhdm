using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using JWHDM.Configuration.Dto;

namespace JWHDM.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : JWHDMAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
