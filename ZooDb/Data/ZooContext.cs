using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZooDb.Models;

namespace ZooDb.Data
{
    public class ZooContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Zoo> Zoos { get; set; }
        public DbSet<AnimalType> AnimalTypes { get; set; }
        public DbSet<Aviary> Aviaries { get; set; }

        public ZooContext(DbContextOptions<ZooContext> options) : base(options)
        {
          
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Zoo>().HasMany(v => v.Animals).WithOne().OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Animal>().HasOne(m => m.Zoo).WithMany(b => b.Animals).HasForeignKey(q => q.ZooId);
            base.OnModelCreating(modelBuilder);
        }
             
    }
}
