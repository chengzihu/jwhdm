using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace JWHDM.EntityFrameworkCore
{
    public static class JWHDMDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<JWHDMDbContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<JWHDMDbContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
