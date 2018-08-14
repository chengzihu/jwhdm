using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JWHDM.Authorization.Roles;
using JWHDM.Authorization.Users;
using JWHDM.MultiTenancy;

namespace JWHDM.EntityFrameworkCore
{
    public class JWHDMDbContext : AbpZeroDbContext<Tenant, Role, User, JWHDMDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JWHDMDbContext(DbContextOptions<JWHDMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TenantAgency.TenantAgency> TenantAgencys { get; set; }
        public virtual DbSet<UserMember.UserMember> UserMembers { get; set; }
        public virtual DbSet<UserEmployee.UserEmployee> UserEmployees { get; set; }
        public virtual DbSet<Challenge.Challenge> Challenges { get; set; }
    }
}
