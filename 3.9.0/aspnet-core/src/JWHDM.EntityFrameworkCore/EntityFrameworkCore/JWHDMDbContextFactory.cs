using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using JWHDM.Configuration;
using JWHDM.Web;

namespace JWHDM.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class JWHDMDbContextFactory : IDesignTimeDbContextFactory<JWHDMDbContext>
    {
        public JWHDMDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<JWHDMDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            JWHDMDbContextConfigurer.Configure(builder, configuration.GetConnectionString(JWHDMConsts.ConnectionStringName));

            return new JWHDMDbContext(builder.Options);
        }
    }
}
