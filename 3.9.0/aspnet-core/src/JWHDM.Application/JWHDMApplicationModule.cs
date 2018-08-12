using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using JWHDM.Authorization;

namespace JWHDM
{
    [DependsOn(
        typeof(JWHDMCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class JWHDMApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<JWHDMAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(JWHDMApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
