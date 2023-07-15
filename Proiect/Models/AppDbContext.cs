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
        public virtual DbSet<Trainer> Trainers{ get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<TrainerGym> TrainerGyms { get; set; }
        public virtual DbSet<Gym> Gyms { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<SessionToken> SessionTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Trainer>()
                .HasMany(o => o.Clients)
                .WithOne(a => a.Trainer);
           
            
            modelBuilder.Entity<TrainerGym>()
                .HasKey(tg => new { tg.TrainerId, tg.GymId });

            modelBuilder.Entity<TrainerGym>()
                .HasOne(tg => tg.Gym)
                .WithMany(g => g.TrainerGyms)
                .HasForeignKey(g => g.GymId);

            modelBuilder.Entity<TrainerGym>()
                .HasOne(tg => tg.Trainer)
                .WithMany(g => g.TrainerGyms)
                .HasForeignKey(g => g.TrainerId);

            modelBuilder.Entity<Gym>()
                .Navigation(g => g.TrainerGyms)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
            
            modelBuilder.Entity<UserRole>().HasKey(arp => new { arp.RoleId, arp.UserId });

           

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
