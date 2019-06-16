using System;
using identity_rest_service.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace identity_rest_service.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
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
            .WithOne(i => i.UserProfile)
            .HasForeignKey<UserProfile>(o => o.UserTypeID);

            builder.Entity<UserProfile>()
            .HasOne(u => u.AgentProfile)
            .WithOne(i => i.UserProfile)
            .HasForeignKey<UserProfile>(o => o.AgentProfileID);
        }
    }
}