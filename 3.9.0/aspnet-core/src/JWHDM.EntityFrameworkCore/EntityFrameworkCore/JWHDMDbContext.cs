using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using JWHDM.Authorization.Roles;
using JWHDM.Authorization.Users;
using JWHDM.MultiTenancy;
using JWHDM.TenantAgencys;
using JWHDM.UserMembers;
using JWHDM.UserEmployees;
using JWHDM.Challenges;
using JWHDM.LessonMinds;
using JWHDM.UserMemberLessonMinds;

namespace JWHDM.EntityFrameworkCore
{
    public class JWHDMDbContext : AbpZeroDbContext<Tenant, Role, User, JWHDMDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public JWHDMDbContext(DbContextOptions<JWHDMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TenantAgency> TenantAgencys { get; set; }
        public virtual DbSet<UserMember> UserMembers { get; set; }
        public virtual DbSet<UserEmployee> UserEmployees { get; set; }
        public virtual DbSet<Challenge> Challenges { get; set; }
        public virtual DbSet<UserMemberLessonMind> UserMemberLessonMinds { get; set; }
        public virtual DbSet<LessonMind> LessonMinds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<PayPay>().Property(p => p.Money).HasColumnType("decimal(18,2)");
            //modelBuilder.Entity<UserMember>().HasMany(t=>t.LessonMinds);
            //modelBuilder.Entity<LessonMind>().HasMany(t=>t.UserMembers);
        }
    }
}
