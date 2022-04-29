using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Mapping;
using YSKProje.ToDo.Entities.Concrete;

namespace YSKProje.ToDo.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class TodoContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.; database=XRTProjeToDoIdentity; integrated security=true ");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.ApplyConfiguration(new DutyMap());
            modelBuilder.ApplyConfiguration(new ReportMap());
            modelBuilder.ApplyConfiguration(new UrgencyMap());
            modelBuilder.ApplyConfiguration(new AppUserMap());

            base.OnModelCreating(modelBuilder);
        }

      
        public DbSet<Duty> Duties { get; set; }
        public DbSet<Urgency> Urgency { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
