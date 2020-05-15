using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using Senac.Domain.Entities;
using Senac.Domain.ValueObjects;
using Senac.Infra.Data.Configuartion;

namespace Senac.Infra.Data.Context
{
    public class SenacContext : DbContext
    {
        public SenacContext(DbContextOptions<SenacContext> options) : base(options)
        {
        }

        public DbSet<Company> Company { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeePosition> EmployeePosition { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("Senac");

            modelBuilder.Ignore<Address>();
            modelBuilder.Ignore<Document>();
            modelBuilder.Ignore<Email>();
            modelBuilder.Ignore<Name>();
            modelBuilder.Ignore<Notification>();

            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeePositionConfiguration());

        }
    }
}
