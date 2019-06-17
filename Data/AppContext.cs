using System;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identity_rest_service.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUser>()
            .HasOne(u => u.UserProfile)
            .WithOne(i => i.AppUser)
            .HasForeignKey<AppUser>(o => o.UserProfileID);

            builder.Entity<UserProfile>()
            .HasOne(u => u.UserType)
            .WithMany(a => a.UserProfiles)
            .HasForeignKey(p => p.UserTypeID);

            builder.Entity<UserProfile>()
            .HasOne(u => u.AgentProfile)
            .WithOne(i => i.UserProfile)
            .HasForeignKey<UserProfile>(o => o.AgentProfileID);
        }
    }
}