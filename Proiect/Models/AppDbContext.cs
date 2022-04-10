using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proiect.Entities;
using Proiect.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect.Models
{
    public class AppDbContext:IdentityDbContext<User, Role, int, IdentityUserClaim<int>,
        UserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Antrenor> Antrenors{ get; set; }
        public DbSet<Adresa> Adresas { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<Om> Oms { get; set; }
        public DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Antrenor>()
                .HasMany(o => o.Oms)
                .WithOne(a => a.Antrenors);

            modelBuilder.Entity<AntrenorGym>().HasKey(arp => new {arp.GymId,arp.AntrenorId });
            modelBuilder.Entity<UserRole>().HasKey(arp => new { arp.RoleId, arp.UserId });

            modelBuilder.Entity<AntrenorGym>()
                .HasOne(arp => arp.Antrenors)
                .WithMany(af => af.AntrenorGyms)
                .HasForeignKey(ur => ur.AntrenorId);

            modelBuilder.Entity<AntrenorGym>()
                .HasOne(arp => arp.Gyms)
                .WithMany(of => of.AntrenorGyms)
                .HasForeignKey(or => or.GymId);

            modelBuilder.Entity<Adresa>()
                .HasOne(a => a.Gyms)
                .WithOne(b => b.Adresas);

            // Autentificare
            modelBuilder.Entity<UserRole>()
                .HasOne(a => a.Role)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(c => c.RoleId);
            modelBuilder.Entity<UserRole>()
                .HasOne(a => a.User)
                .WithMany(b => b.UserRoles)
                .HasForeignKey(c => c.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
