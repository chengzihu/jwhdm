using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JWHDM.Configuration;

namespace JWHDM.Web.Host.Startup
{
    [DependsOn(
       typeof(JWHDMWebCoreModule))]
    public class JWHDMWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public JWHDMWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(JWHDMWebHostModule).GetAssembly());
        }
    }
}
