using System.Threading.Tasks;
using JWHDM.Configuration.Dto;

namespace JWHDM.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
