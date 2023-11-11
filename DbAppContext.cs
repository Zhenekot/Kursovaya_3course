using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourAgentCreatour
{
    internal class DbAppContext : DbContext
    {
        public DbSet<transport> transport { get; set; }
        public DbSet<tour> tour { get; set; }
        public DbSet<hotel> hotel { get; set;  }
        public DbSet<employee> employee { get; set; }
        public DbSet<sale> sale { get; set; }
        public DbSet<client> client { get; set; }
        public DbSet<position> position { get; set; }
        public DbSet<transportation> transportation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host= localhost; Username=postgres; Password=123; Database=KursovayaCreatourFour");
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<transportation>().HasOne(p => p.TourEntity).WithMany(p => p.TransportationEntity);
            modelBuilder.Entity<transportation>().HasOne(p => p.transportEntity).WithMany(p => p.TransportationEntity);

            modelBuilder.Entity<employee>().HasOne(p => p.PositionEntity).WithMany(p => p.EmployeeEntity);

            modelBuilder.Entity<sale>().HasOne(p => p.TransportationEntity).WithMany(p => p.SaleEntity);

            modelBuilder.Entity<sale>().HasOne(p => p.EmployeeEntity).WithMany(p => p.SaleEntity);

            modelBuilder.Entity<sale>().HasOne(p => p.ClientEntity).WithMany(p => p.SaleEntity);

            modelBuilder.Entity<sale>().HasOne(p => p.HotelEntity).WithMany(p => p.SaleEntity);
        }
    }
}
